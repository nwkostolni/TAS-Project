function getEmployees(){
    const EmployeeApiUrl = "https://localhost:5001/api/Employee";

    fetch(EmployeeApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function append_json(json){
        var table = document.getElementById('dataTable');
        json.forEach(function(object) {
            var tr = document.createElement('tr');
            tr.innerHTML = '<td>' + object.EmpId + '</td>' +
            '<td>' + object.EmpLast + '</td>' +
            '<td>' + object.EmpFirst + '</td>' +
            '<td>' + object.EmpEmail + '</td>' +
            '<td>' + object.EmpDept + '</td>' +
            '<td>' + object.EmpLevel + '</td>' ;
            table.appendChild(tr);
        });
    }).catch(function(error){
        console.log(error);
    });
}




function append_json(data){
    var table = document.getElementById('dataTable');
    data.forEach(function(object) {
        var tr = document.createElement('tr');
        tr.innerHTML = '<td>' + object.EmpId + '</td>' +
        '<td>' + object.EmpLast + '</td>' +
        '<td>' + object.EmpFirst + '</td>' +
        '<td>' + object.EmpEmail + '</td>' +
        '<td>' + object.EmpDept + '</td>' +
        '<td>' + object.EmpLevel + '</td>' ;
        table.appendChild(tr);
    });
}







// function getEmployees(){
//     const EmployeeApiUrl = "https://localhost:5001/api/Employee";

//     fetch(EmployeeApiUrl).then(function(response){
//         console.log(response);
//         return response.json();
//     }).then(function(json){
//         let html= "<tr>";
//         json.forEach((Employee)=>{
            
//             html += "<td>" +  Employee.EmpID + "</td>";
//             html += "<td>" +  Employee.EmpFirst + "</td>";
//             html += "<td>" +  Employee.EmpLast + "</td>";
//             html += "<td>" +  Employee.EmpEmail + "</td>";
//             html += "<td>" +  Employee.EmpDept + "</td>";
//             html += "<td>" +  Employee.EmpLevel + "</td>";
            
//         })
//         html += "</tr>"
//         document.getElementById("Employee").innerHTML=html;
//     }).catch(function(error){
//         console.log(error);
//     });
// }