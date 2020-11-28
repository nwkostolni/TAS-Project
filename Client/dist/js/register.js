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

function getCreateEmpButton(){
    let html = "<input class=\"btn btn-primary btn-block\" type=\"submit\" value=\"Create Employee Account\"onclick=\"preAddEmployee()\" />"; 
    document.getElementById("createEmpButton").innerHTML=html; 
}

function preAddEmployee(){
    const allEmployeesApiUrl = "https://localhost:5001/api/Employee";

    fetch(allEmployeesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let id=0;
        json.forEach((Employee)=>{
            id++;
        })
        id++;
        AddEmployee(id);
    }).catch(function(error){
        console.log(error);
    });
} 

function AddEmployee(id){
    const formId= id;
    const formFirstName= document.getElementById("inputFirstName").value;
    const formLastName= document.getElementById("inputLastName").value;
    const formEmail= document.getElementById("inputEmailAddress").value;
    const formDepartment= document.getElementById("inputDepartment").value;
    const formLevel= document.getElementById("inputLevel").value;
    const formMgrId= +document.getElementById("inputMgrId").value;
    const preFormAdmin= document.querySelector('input[id=\'inputAdmin\']:checked') ? 1 : 0
    const formAdmin = new Boolean(preFormAdmin);
    const formPassword=document.getElementById("inputPassword").value;
    if(document.getElementById("inputPassword").value != document.getElementById("inputConfirmPassword").value){
        alert("Passwords do not match. Make sure the passwords match, then click create again.");
        return;
    }
    const addEmployeeApiUrl = "https://localhost:5001/api/Employee";

    fetch(addEmployeeApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            EmpId: formId,
            EmpFirst: formFirstName,
            EmpLast: formLastName,
            EmpEmail: formEmail,
            EmpDep: formDepartment,
            EmpLvl: formLevel,
            Admin: formAdmin,
            MgrId: formMgrId,
            Password: formPassword
        })
    })
    .then((response)=>{
        console.log(response);
        window.location.href = "admin-employee.html?userId="+userId;
    })
}