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

function getAssignSurveyButton(){
    let html = "<input class=\"btn btn-primary btn-block\" type=\"submit\" value=\"Assign Survey\" onclick=\"preAddSurvey()\"/>";
    document.getElementById("assignSurveyButton").innerHTML=html; 
}

function preAddSurvey(){
    const allSurveysApiUrl = "https://localhost:5001/api/Survey";

    fetch(allSurveysApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let id=0;
        json.forEach((Survey)=>{
            id++;
        })
        id++;
        AddSurvey(id);
    }).catch(function(error){
        console.log(error);
    });
} 

function AddSurvey(id){
    const formId= id;
    const formCycle= document.getElementById("inputCycle").value;
    const formReviewerEmpId= +document.getElementById("inputReviewerEmpId").value;
    const formSubjectEmpId= +document.getElementById("inputSubjectEmpId").value;
    var formDateDue= new Date(document.getElementById("inputDateDue").value).toJSON();
    const formBeenCompleted= new Boolean(false);
    const formDateCompleted= null;

    const addSurveyApiUrl = "https://localhost:5001/api/Survey";

    fetch(addSurveyApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            surveyId: formId,
            cycle: formCycle,
            reviewerEmpId: formReviewerEmpId,
            subjectEmpId: formSubjectEmpId,
            dateDue: formDateDue,
            beenCompleted: formBeenCompleted,
            dateCompleted: formDateCompleted
        })
    })
    .then((response)=>{
        console.log(response);
        window.location.href = "admin-tasks.html?userId="+userId;
    })
}