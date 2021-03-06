//get url
const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
//remove user from url and put in global variable
var userId = urlParams.get('userId');


function getUserName(){
    const allEmployeesApiUrl = "https://localhost:5001/api/Employee";

    fetch(allEmployeesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html;
        json.forEach((Employee)=>{
            if(Employee.empId==userId){
                html = Employee.empFirst + " " + Employee.empLast;
            }
        })
        document.getElementById("userName").innerHTML=html; 
        document.getElementById("userName2").innerHTML=html; 
    }).catch(function(error){
        console.log(error);
    });
}

function getAdmin(){
    const allEmployeesApiUrl = "https://localhost:5001/api/Employee";

    fetch(allEmployeesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html;
        json.forEach((Employee)=>{
            if(Employee.empId==userId){
                if(Employee.admin==1){
                    html = "<a class=\"dropdown-item\" href=\"admin-functions.html?userId="+userId+"\">Admin Functions</a>";
                }
                else{
                    html = "";
                }
            }
        })
        document.getElementById("adminPriv").innerHTML=html; 
    }).catch(function(error){
        console.log(error);
    });
}

function getDashboard(){
    let html = "<a class=\"nav-link\" href=\"index.html?userId="+userId+"\"><div class=\"sb-nav-link-icon\"><i class=\"fas fa-tachometer-alt\"></i></div>User Dashboard</a>";
    document.getElementById("dashboard").innerHTML=html; 
}

function getTaskList(){
    let html = "<a class=\"nav-link\" href=\"task-list.html?userId="+userId+"\"><div class=\"sb-nav-link-icon\"><i class=\"fas fa-columns\"></i></div>Task List</a>";
    document.getElementById("taskList").innerHTML=html; 
}

function getManagedEmployees(){
    const allEmployeesApiUrl = "https://localhost:5001/api/Employee";

    fetch(allEmployeesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html="";
        json.forEach((Employee)=>{
            if(Employee.mgrId==userId){
                let managedEmployee = Employee.empId;
                html += "<a class=\"nav-link collapsed\" href=\"#\" data-toggle=\"collapse\" data-target=\"#collapsePages\" aria-expanded=\"false\" aria-controls=\"collapsePages\">";
                html +="<div class=\"sb-nav-link-icon\"><i class=\"fas fa-tachometer-alt\"></i></div>";
                html +=Employee.empFirst +" "+Employee.empLast;
                html +="<div class=\"sb-sidenav-collapse-arrow\"><i class=\"fas fa-angle-down\"></i></div>";
                html +="</a>";
                html +="<div class=\"collapse\" id=\"collapsePages\" aria-labelledby=\"headingTwo\" data-parent=\"#sidenavAccordion\">";
                html +="<nav class=\"sb-sidenav-menu-nested nav accordion\" id=\"sidenavAccordionPages\">";
                html +="<a class=\"nav-link\" href=\"index2.html?userId="+managedEmployee+"&manager="+userId+"\">Dashboard</a>";
                html +="<a class=\"nav-link\" href=\"task-list2.html?userId="+managedEmployee+"&manager="+userId+"\">Tasks</a>";
                html +="</nav></div>";
            }
        })
        document.getElementById("managedEmployees").innerHTML=html; 
    }).catch(function(error){
        console.log(error);
    });
}

function getAddEmployeeButton(){
    let html = "<a class=\"small text-white stretched-link\" href=\"register.html?userId="+userId+"\"></a>";
    document.getElementById("addEmployeeButton").innerHTML=html; 
}

function getEmployees(){
    const allEmployeesApiUrl = "https://localhost:5001/api/Employee";

    fetch(allEmployeesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<tr>";
        json.forEach((Employee)=>{
            html +="<td>" + Employee.empId + "</td>";
            html +="<td>" + Employee.empFirst + " " + Employee.empLast + "</td>";
            html +="<td>" + Employee.empEmail + "</td>";
            html +="<td>" + Employee.empDep + "</td>";
            html +="<td>" + Employee.empLvl + "</td>";
            if(Employee.admin==1){
                html +="<td><span class=\"material-icons\">check_box</span></td>";
            }
            else{
                html +="<td><span class=\"material-icons\">check_box_outline_blank</span></td>";
            }
            html +="<td>" + Employee.password + "</td>";
            html +="<td>" + Employee.mgrId + "</td>";
            html +="<td><span class=\"material-icons cursor\" onclick=\"editEmployee("+Employee.empId+")\">edit</span><text>  </text><span class=\"material-icons cursor\" onclick=\"deleteEmployee("+Employee.empId+")\">delete</span></td>";
            html += "</tr>";
            html += "<tr>";
        })
        html += "</tr>";
        document.getElementById("empTable").innerHTML=html; 
    }).catch(function(error){
        console.log(error);
    });
}

function editEmployee(editId){
    window.location.href = "editEmployee.html?userId=" + userId + "&editId=" +editId;
}

function deleteEmployee(editId){
    if (confirm('Are you sure you want to remove this employee?')) {
        // Remove
        deleteEmployeeConfirmed(editId);
        location.reload();
        alert("Employee has been removed.");
    } 
    else {
        // Cancel
    }
}

function deleteEmployeeConfirmed(editId){
    const deleteEmployeeApiUrl="https://localhost:5001/api/Employee";

    fetch(deleteEmployeeApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            empId: editId
        })
    })
    .then((response)=>{
        console.log(response);
    })
}