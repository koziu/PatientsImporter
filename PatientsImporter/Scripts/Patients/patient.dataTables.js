//$(document).ready(function () {
//	$("#patientTable").DataTable();
//});

$(document).ready(function () {
  var tableLenght = $('#patientTable thead th').length;
  var table = $('#patientTable').DataTable({
    "columnDefs": [
        {
          "targets": [tableLenght - 1],
          "searchable": false,
          "orderable": false
        }
    ]
  });

  $("#patientTable tfoot th").each(function () {
      var title = $("#patientTable thead th").eq($(this).index()).text();
      title = title.toLowerCase().replace(/\s+/, "");
      $(this).html('<input type="text" placeholder=" Filtruj ' + title + '" />');
  });

  table.columns().eq(0).each(function (colIdx) {
    $("input", table.column(colIdx).footer()).on("keyup change", function () {
      table
          .column(colIdx)
          .search(this.value)
          .draw();
    });
  });
})