var useCaseTable = $("#table");
$(function () {
    useCaseTable.bootstrapTable({
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
        detailFormatter: useCaseDetailFormatter,
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
        onCheckAll: onCheckAllUseCases,
        onUncheckAll: onUncheckAllUseCases,
        onCheck: onCheckUseCase,
        onUncheck: onUncheckUseCase,
        onPostBody: onPostBodyUseCase
    });
});

function useCaseDetailFormatter(index, row) {
    var html = [];
    $.each(row, function (key, value) {
        html.push('<p><b>' + key + ':</b> ' + (!value ? "false" : value) + '</p>');
    });
    return html.join('');
}

function onCheckAllUseCases(rowsAfter, rowsBefore) {
    localStorage.setItem("useCases", JSON.stringify(rowsAfter));
}

function onUncheckAllUseCases() {
    localStorage.setItem("useCases", JSON.stringify([]));
}

function onCheckUseCase(row, element) {
    const rows = JSON.parse(localStorage.getItem("useCases"));
    rows.push(row);
    localStorage.setItem("useCases", JSON.stringify(rows));
}

function onUncheckUseCase(row, element) {
    const rows = JSON.parse(localStorage.getItem("useCases"));

    var filtered = rows.filter(function (value, index, arr) {
        return value.Code !== row.Code;
    });
    localStorage.setItem("useCases", JSON.stringify(filtered));
}

function onPostBodyUseCase() {
    const rows = JSON.parse(localStorage.getItem("useCases"));
    if (!rows) {
        return;
    }

    const codes = [];

    for (let i = 0; i < rows.length; i++) {
        codes.push(rows[i].Code);
    }
    
    useCaseTable.bootstrapTable("checkBy", {
        field: "Code",
        values: codes
    });
}