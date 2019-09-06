var table = $("#table");
$(function () {
    table.bootstrapTable({
        clickToSelect: true,
        sortable: true,
        search: true,
        cookie: true,
        cookieIdTable: "UseCaseCookID",
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
        url: $("#GetUseCasesUrl").val(),
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

function detailFormatter(index, row) {
    var html = [];
    $.each(row, function (key, value) {
        html.push('<p><b>' + key + ':</b> ' + (!value ? "false" : value) + '</p>');
    });
    return html.join('');
}

function onCheckAll(rowsAfter, rowsBefore) {
    localStorage.setItem("useCases", JSON.stringify(rowsAfter));
}

function onUncheckAll() {
    localStorage.setItem("useCases", JSON.stringify([]));
}

function onCheck(row, element) {
    const rows = JSON.parse(localStorage.getItem("useCases")) || [];
    rows.push(row);
    localStorage.setItem("useCases", JSON.stringify(rows));
}

function onUncheck(row, element) {
    const rows = JSON.parse(localStorage.getItem("useCases"));

    var filtered = rows.filter(function (value, index, arr) {
        return value.Code !== row.Code;
    });
    localStorage.setItem("useCases", JSON.stringify(filtered));
}

function onPostBody() {
    const rows = JSON.parse(localStorage.getItem("useCases"));
    if (!rows) {
        return;
    }

    const codes = [];

    for (let i = 0; i < rows.length; i++) {
        codes.push(rows[i].Code);
    }
    
    table.bootstrapTable("checkBy", {
        field: "Code",
        values: codes
    });
}