// Call the dataTables jQuery plugin
$(document).ready(function() {
  $('#dataTable').DataTable({
    "paging": false,
    "info": false
  });
});

$(document).ready(function() {
  $('#dataTableDashboard').DataTable({
    "paging": false,
    "info": false,
    "columnDefs": [
      { "width": "65%", "targets": 0 }
    ]
  });
});
