var productController = function () {
    this.initialize = function () {
        loadDataCategories();
        loadData(false);
        registerEvent();
    }
    function registerEvent() {
        
        $("#ddlShowPage").on("change", function () {
            common.configs.pageSize = $(this).val();
            common.configs.pageIndex = 1;
            loadData(true);
        });
        $("#txtKeyword").on("keypress", function (e) {
            if (e.which === 13) {
                loadData(true);
            }
        });
        $("#btnGo").on("click", function () {
            loadData(true);
        });
        $("#btnCreate").on("click", function () {
            resetFormMaintainance();
            initTreeDropDownCategory();
            $("#modal-add-edit").modal("show");
        });
        $("body").on("click", ".btn-edit", function (e) {
            e.preventDefault();
            var that = $(this).data("id");
            $.ajax({
                type: "GET",
                url: "/Admin/Product/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    common.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#hidIdM').val(data.Id);
                    $('#txtNameM').val(data.Name);
                    initTreeDropDownCategory(data.CategoryId);

                    $('#txtDescM').val(data.Description);
                    $('#txtUnitM').val(data.Unit);

                    $('#txtPriceM').val(data.Price);
                    $('#txtOriginalPriceM').val(data.OriginalPrice);
                    $('#txtPromotionPriceM').val(data.PromotionPrice);

                    // $('#txtImageM').val(data.ThumbnailImage);

                    $('#txtTagM').val(data.Tags);
                    $('#txtMetakeywordM').val(data.SeoKeywords);
                    $('#txtMetaDescriptionM').val(data.SeoDescription);
                    $('#txtSeoPageTitleM').val(data.SeoPageTitle);
                    $('#txtSeoAliasM').val(data.SeoAlias);

                    //CKEDITOR.instances.txtContentM.setData(data.Content);
                    $('#ckStatusM').prop('checked', data.Status == 1);
                    $('#ckHotM').prop('checked', data.HotFlag);
                    $('#ckShowHomeM').prop('checked', data.HomeFlag);

                    $('#modal-add-edit').modal('show');
                    common.stopLoading();

                },
                error: function (status) {
                    common.notify('Có lỗi xảy ra', 'error');
                    common.stopLoading();
                }
            });
        });
        $('body').on('click', '.btn-delete', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            common.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Product/Delete",
                    data: { id: that },
                    dataType: "json",
                    beforeSend: function () {
                        common.startLoading();
                    },
                    success: function (response) {
                        common.notify('Delete successful', 'success');
                        common.stopLoading();
                        loadData();
                    },
                    error: function (status) {
                        common.notify('Has an error in delete progress', 'error');
                        common.stopLoading();
                    }
                });
            });
        });
    }
    function initTreeDropDownCategory(selectedId) {
        $.ajax({
            url: "/Admin/ProductCategory/GetAll",
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (response) {
                var data = [];
                $.each(response, function (i, item) {
                    data.push({
                        id: item.Id,
                        text: item.Name,
                        parentId: item.ParentId,
                        sortOrder: item.SortOrder
                    });
                });
                var arr = common.unflattern(data);
                $('#ddlCategoryIdM').combotree({
                    data: arr
                });
                if (selectedId !== undefined) {
                    $('#ddlCategoryIdM').combotree('setValue', selectedId);
                }
            }
        });
    }
    function resetFormMaintainance() {
        $('#hidIdM').val(0);
        $('#txtNameM').val('');
        initTreeDropDownCategory('');

        $('#txtDescM').val('');
        $('#txtUnitM').val('');

        $('#txtPriceM').val('0');
        $('#txtOriginalPriceM').val('');
        $('#txtPromotionPriceM').val('');

        //$('#txtImageM').val('');

        $('#txtTagM').val('');
        $('#txtMetakeywordM').val('');
        $('#txtMetaDescriptionM').val('');
        $('#txtSeoPageTitleM').val('');
        $('#txtSeoAliasM').val('');

        //CKEDITOR.instances.txtContentM.setData('');
        $('#ckStatusM').prop('checked', true);
        $('#ckHotM').prop('checked', false);
        $('#ckShowHomeM').prop('checked', false);

    }

    function loadDataCategories() {
        var control = $("#cbCategory");
        $.ajax({
            type: "GET",
            data: "",
            url: "/admin/product/GetAllCategories",
            dataType: "json",
            success: function (response) {
                $.each(response, function (i, item) {
                    control.append($("<option>", { value: item.Id, text: item.Name}));
                });
            },
            error: function (status) {
                console.log(status);
                common.notify("MotorHomepage", "Cant loading data", "gray error");
            }
        });
    }
    function loadData(isPageChange) {
        var template = $("#table-template").html();
        var render = "";
        $.ajax({
            type: "GET",
            data: {
                categoryId: $("#cbCategory").val(),
                keyword: $("#txtKeyword").val(),
                page: common.configs.pageIndex,
                pageSize: common.configs.pageSize
            },
            url: "/admin/product/GetAllPaging",
            dataType: "json",
            success: function (response) {
                if (response.Results.length === 0) {
                    $("#tbl-content").html("");
                    $("#tbl-content").append($("<tr>").append($("<td>").attr("colspan", 8).html("There is no data to display!!").addClass("text-center")));                    
                }
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Name: item.Name,
                        Image: item.Image === null ? "<img scr='~/assets/material-admin/img/avatar1.jpg' width=25 />" : "<img scr='" + item.Image + "' width=25 />",
                        CategoryName: item.ProductCategory.Name,
                        Price: common.formatNumber(item.Price, 0),
                        CreatedDate: common.dateTimeFormatJson(item.DateCreated),
                        Status: common.getStatus(item.Status)
                    });
                    if (render !== "") {
                        $("#tbl-content").html(render);
                        $("#lblTotalRecord").html(response.RowCount);
                    }
                    
                });
                wrapPaging(response.RowCount, function () {
                    loadData();
                }, isPageChange);
            },
            error: function (status) {
                console.log(status);
                common.notify("MotorHomepage", "Cant loading data", "gray error");
            }
        });
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalSize = Math.ceil(recordCount / common.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($("#paginationUl a").length === 0 || changePageSize === true) {
            $("#paginationUl").empty();
            $("#paginationUl").removeData("twbs-pagination");
            $("#paginationUl").unbind("page");
        }
        //Bind Pagination Event
        $("#paginationUl").twbsPagination({
            totalPages: totalSize,
            visiblePages: 7,
            onPageClick: function (e, p) {
                common.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }


}