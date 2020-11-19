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
    let html = "<a class=\"btn btn-primary btn-block\" type=\"submit\" onclick=\"editEmployee()\" href=\"admin-employee.html?userId="+userId+"\">Edit Employee Account</a>";
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
                    document.getElementById("inputPassword").placeholder = Employee.password;
                    document.getElementById("inputConfirmPassword").placeholder = Employee.password;
                }
            })
    }).catch(function(error){
        console.log(error);
    });
}

function editEmployee(){
    const editEmployeeApiUrl="https://localhost:5001/api/Employee";
    alert("INSIDE editEmployee");
    const employeeFirst ="";
    if(document.getElementById("inputFirstName").value == null){
        employeeFirst=editId.empFirst;
    }
    else{
        employeeFirst=document.getElementById("inputFirstName").value;
    }

    const employeeLast="";
    if(document.getElementById("inputLastName").value == null){
        employeeLast=editId.empLast;
    }
    else{
        employeeLast=document.getElementById("inputLastName").value;
    }
    
    const employeeEmail="";
    if(document.getElementById("inputEmailAddress").value == null){
        employeeEmail=editId.empEmail;
    }
    else{
        employeeEmail=document.getElementById("inputEmailAddress").value;
    }

    const employeeDep="";
    if(document.getElementById("inputDepartment").value == null){
        employeeDep=editId.empDep;
    }
    else{
        employeeDep=document.getElementById("inputDepartment").value;
    }

    const employeeLvl="";
    if(document.getElementById("inputLevel").value == null){
        employeeLvl=editId.empLvl;
    }
    else{
        employeeLvl=document.getElementById("inputLevel").value;
    }

    const employeeAdmin="";
    if((document.getElementById("yesAdmin").value == null)&&(document.getElementById("noAdmin").value == null)){
        employeeAdmin=editId.admin;
    }
    else if ((document.getElementById("yesAdmin").value != null)&&(document.getElementById("noAdmin").value == null)){
        employeeAdmin=1;
    }
    else{
        employeeAdmin=0;
    }

    const employeeMgrId="";
    if(document.getElementById("inputMgrId").value == null){
        employeeMgrId=editId.mgrId;
    }
    else{
        employeeMgrId=document.getElementById("inputMgrId").value;
    }

    const employeePassword="";
    if(document.getElementById("inputPassword").value == null){
        employeePassword=editId.Password;
    }
    else{
        employeePassword=document.getElementById("inputPassword").value;
    }

    fetch(editEmployeeApiUrl, {
        method: "Put", 
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            empId: editId,
            empFirst: employeeFirst,
            empLast: employeeLast,
            empEmail: employeeEmail,
            empDep: employeeDep,
            empLvl: employeeLvl,
            admin: employeeAdmin ,
            mgrId: employeeMgrId,
            password: employeePassword
        })

    })
    .then((response)=>{
        console.log(response);
    })
}


