//get url
const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
//remove user from url and put in global variable
var userId = urlParams.get('userId');
//remove editId from url and put in global variable
var editId = urlParams.get('editId');


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

function getEditEmpButton(){
    let html = "<a class=\"btn btn-primary btn-block\" type=\"submit\"  onclick=\"editEmployee1()\" >Edit Employee Account</a>"; //href=\"admin-employee.html?userId="+userId+"\"
    document.getElementById("editEmpButton").innerHTML=html; 
}

function setPlaceholders(){
    
    const allEmployeesApiUrl = "https://localhost:5001/api/Employee";

    fetch(allEmployeesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
            json.forEach((Employee)=>{
                if(Employee.empId==editId){
                    document.getElementById("inputFirstName").placeholder = Employee.empFirst;
                    document.getElementById("inputLastName").placeholder = Employee.empLast;
                    document.getElementById("inputEmailAddress").placeholder = Employee.empEmail;
                    document.getElementById("inputDepartment").placeholder = Employee.empDep;
                    document.getElementById("inputLevel").placeholder = Employee.empLvl;
                    document.getElementById("inputMgrId").placeholder = Employee.mgrId;
                    if(Employee.admin==1){
                        document.getElementById("inputAdmin").checked = true;
                    }
                    else{
                        document.getElementById("inputAdmin").checked = false;
                    }
                    document.getElementById("inputPassword").placeholder = Employee.password;
                    document.getElementById("inputConfirmPassword").placeholder = Employee.password;
                }
            })
    }).catch(function(error){
        console.log(error);
    });
}

function editEmployee1(){
    const editEmployeeApiUrl="https://localhost:5001/api/Employee";

    fetch(editEmployeeApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
            json.forEach((Employee)=>{
                if(Employee.empId==editId){
                    const employeeId = Employee.empId;
                    const employeeFirst = document.getElementById("inputFirstName").value ?
                    document.getElementById("inputFirstName").value : Employee.empFirst
                
                    const employeeLast=document.getElementById("inputLastName").value ?
                    document.getElementById("inputLastName").value : Employee.empLast
                    
                    const employeeEmail=document.getElementById("inputEmailAddress").value ?
                    document.getElementById("inputEmailAddress").value : Employee.empEmail
                
                    const employeeDep=document.getElementById("inputDepartment").value ?
                    document.getElementById("inputDepartment").value : Employee.empDep
                
                    const employeeLvl=document.getElementById("inputLevel").value ?
                    document.getElementById("inputLevel").value : Employee.empLvl
                
                    const employeeAdmin= document.getElementById("inputAdmin").value ?
                    false : true 
                
                    const employeeMgrId=document.getElementById("inputMgrId").value ?
                    document.getElementById("inputMgrId").value : Employee.mgrId
                
                    const employeePassword=document.getElementById("inputPassword").value ?
                    document.getElementById("inputPassword").value : Employee.password

                    editEmployee2(employeeId, employeeFirst, employeeLast, employeeEmail, employeeDep, employeeLvl, employeeAdmin, employeeMgrId, employeePassword);
                }
            })
    }).catch(function(error){
        console.log(error);
    });
}

function editEmployee2(employeeId, employeeFirst, employeeLast, employeeEmail, employeeDep, employeeLvl, employeeAdmin, employeeMgrId, employeePassword){
    const editEmployee2ApiUrl="https://localhost:5001/api/Employee";

    fetch(editEmployee2ApiUrl, {
        method: "PUT", 
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            empId: employeeId,
            empFirst: employeeFirst,
            empLast: employeeLast,
            empEmail: employeeEmail,
            empDep: employeeDep,
            empLvl: employeeLvl,
            admin: employeeAdmin,
            mgrId: employeeMgrId,
            password: employeePassword
        })
    })
    .then((response)=>{
        console.log(response);
        window.location.href = "admin-employee.html?userId="+userId;
    })
}