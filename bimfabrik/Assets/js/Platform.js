function platformDetailFormatter(index, row) {
    var html = [];
    $.each(row, function (key, value) {
        html.push('<p><b>' + key + ':</b> ' + (!value ? "false" : value) + '</p>');
    });
    return html.join('');
}

window.platformDetailFormatter = platformDetailFormatter;