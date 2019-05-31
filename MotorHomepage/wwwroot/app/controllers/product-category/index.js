var productCategoryController = function () {
    this.initialize = function () {
        loadData();
        registerEvent();
    }
    function registerEvent() {
        $("#btnCreate").off("click").on("click", function () {
            $("#mdProductCategoryDetail").modal("show");
        });
        $("body").on("click", "#btnEdit", function (e) {
            e.preventDefault();
            var that = $("#hdfProductCategoryId").val();
            $.ajax({
                type: "GET",
                url: "/Admin/ProductCategory/GetById",
                data: { id: that },
                dataType: "json",
                beforeSend: function () {
                    common.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $("#hdfIdM").val(data.Id);
                    $("#txtNameM").val(data.Name);
                    initTreeDropDownCategory(data.CategoryId);
                    $("#txtDescM").val(data.Description);
                    $("#txtImageM").val(data.ThumbnailImage);
                    $("#txtSeoKeywordM").val(data.SeoKeywords);
                    $("#txtSeoDescriptionM").val(data.SeoDescription);
                    $("#txtSeoPageTitleM").val(data.SeoPageTitle);
                    $("#txtSeoAliasM").val(data.SeoAlias);

                    $("#ckStatusM").prop("checked", data.Status === 0);
                    $("#ckShowHomeM").prop("checked", data.HomeFlag === 0);

                    $("#txtOrderM").val(data.SortOrder);
                    $("#txtHomeOrderM").val(data.HomeOrder);

                    $("#mdProductCategoryDetail").modal("show");
                    common.stopLoading();
                },
                error: function (status) {
                    common.notify("MotorHomepage", "Has some error occur", "gray error");
                }
            });

        });
        $("body").on("click", "#btnDelete", function () {

        });
    }
    function loadData() {
        $.ajax({
            url: "/Admin/ProductCategory/GetAll",
            dataType: "json",
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
                var treeArray = common.unflattern(data);
                treeArray.sort(function (a, b) {
                    return a.sortOrder - b.sortOrder;
                });
                var $tree = $("#treeProductCategory");

                $tree.tree({
                    data: treeArray,
                    dnd: true,
                    onContextMenu: function (e, node) {
                        e.preventDefault();
                        console.log(e);
                        // select the node
                        $tree.tree('select', node.target);
                        // display context menu
                        $('#contextMenu').menu('show', {
                            left: e.pageX,
                            top: e.pageY
                        });

                        $("#hdfProductCategoryId").val(node.id);
                    },
                    onDrop: function (target, source, point) {
                        var targetNode = $(this).tree("getNode", target);
                        if (point === "append") {
                            var children = [];
                            $.each(targetNode.children, function (i, item) {
                                children.push({
                                    key: item.id,
                                    value: i
                                });
                            });

                            //update to database

                            $.ajax({
                                url: "/Admin/ProductCategory/UpdateParentId",
                                type: "post",
                                dataType: "json",
                                data: {
                                    sourceId: source.id, targetId: targetNode.id, items: children
                                },
                                success: function (response) {
                                    loadData();
                                }
                            });

                        } else if (point === "top" || point === "bottom") {
                            $.ajax({
                                url: "/Admin/ProductCategory/ReOrder",
                                type: "post",
                                dataType: "json",
                                data: {
                                    sourceId: source.id, targetId: targetNode.id
                                },
                                success: function (response) {
                                    loadData();
                                }
                            });
                        }
                    }
                });
            }
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
                $("#ddlCategoryIdM").next().css("width", "100%");
            }
        });
    }
}