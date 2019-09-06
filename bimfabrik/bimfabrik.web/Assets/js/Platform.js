var table = $("#table");
$(function () {
    table.bootstrapTable({
        clickToSelect: true,
        sortable: true,
        search: true,
        cookie: true,
        cookieIdTable: "platformCookID",
        showRefresh: false,
        showToggle: true,
        showFullscreen: true,
        showColumns: true,
        detailView: true,
        detailFormatter: detailFormatter,
        showExport: true,
        minimumCountColumns: 2,
        showPaginationSwitch: true,
        pagination: true,
        idDield: "ID",
        pageList: [10, 25, 50, 100, "all"],
        showFooter: true,
        showPrint: true,
        locale: "de-DE",
        url: $("#GetPlatformUrl").val(),
        cache: true,
        filterControl: true,
        maintainMetaData: true,
        showSearchClearButton: true,
        onCheckAll: onCheckAll,
        onUncheckAll: onUncheckAll,
        onCheck: onCheck,
        onUncheck: onUncheck,
        onPostBody: onPostBody
    });
});

function onCheckAll(rowsAfter, rowsBefore) {
    localStorage.setItem("platform", JSON.stringify(rowsAfter));
}

function onUncheckAll() {
    localStorage.setItem("platform", JSON.stringify([]));
}

function onCheck(row, element) {
    const rows = JSON.parse(localStorage.getItem("platform")) || [];
    rows.push(row);
    localStorage.setItem("platform", JSON.stringify(rows));
}

function onUncheck(row, element) {
    const rows = JSON.parse(localStorage.getItem("platform"));

    var filtered = rows.filter(function (value, index, arr) {
        return value.Code !== row.Code;
    });
    localStorage.setItem("platform", JSON.stringify(filtered));
}

function onPostBody() {
    const rows = JSON.parse(localStorage.getItem("platform"));
    if (!rows) {
        return;
    }

    const names = [];

    for (let i = 0; i < rows.length; i++) {
        names.push(rows[i].Name);
    }

    table.bootstrapTable("checkBy", {
        field: "Name",
        values: names
    });
}

function detailFormatter(index, row) {
    var html = [];
    $.each(row, function (key, value) {
        html.push('<p><b>' + key + ':</b> ' + (!value ? "false" : value) + '</p>');
    });
    return html.join('');
}