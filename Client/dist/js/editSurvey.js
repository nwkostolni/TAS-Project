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

function getEditSurveyButton(){
    let html = "<a class=\"btn btn-primary btn-block\" type=\"submit\"  onclick=\"editSurvey1()\" >Edit Survey</a>";
    document.getElementById("editSurveyButton").innerHTML=html; 
}
function setPlaceHolders(){
    const allSurveysApiUrl = "https://localhost:5001/api/Survey";

    fetch(allSurveysApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        json.forEach((Survey)=>{
            if(Survey.surveyId==editId){
                document.getElementById("inputReviewerId").placeholder = Survey.reviewerEmpId;
                document.getElementById("inputSubjectId").placeholder = Survey.subjectEmpId;
                document.getElementById("inputCycle").placeholder = Survey.cycle;
                document.getElementById("inputDateDue").placeholder = Survey.dateDue;
            }
        })
    }).catch(function(error){
        console.log(error);
    });
}

function editSurvey1(){
    const editSurveyApiUrl="https://localhost:5001/api/Survey";
    fetch(editSurveyApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
            json.forEach((Survey)=>{
                if(Survey.surveyId==editId){
                    const SurveyId = Survey.surveyId;

                    const SurveyCycle = document.getElementById("inputCycle").value ?
                    document.getElementById("inputCycle").value : Survey.cycle
                
                    const SurveyReviewerId=document.getElementById("inputReviewerId").value ?
                    +document.getElementById("inputReviewerId").value : Survey.reviewerEmpId
                    
                    const SurveySubjectId=document.getElementById("inputSubjectId").value ?
                    +document.getElementById("inputSubjectId").value : Survey.subjectEmpId
                
                    if(document.getElementById("inputDateDue").value == ""){
                        alert("A Due Date must be entered.");
                        return;
                    }

                    var SurveyDateDue= new Date(document.getElementById("inputDateDue").value).toJSON();


                    const SurveyBeenCompleted = Survey.beenCompleted;

                    var SurveyDateCompleted = new Date(Survey.dateCompleted).toJSON();

                    editSurvey2(SurveyId, SurveyCycle, SurveyReviewerId, SurveySubjectId, SurveyDateDue, SurveyBeenCompleted, SurveyDateCompleted);
                }
            })
    }).catch(function(error){
        console.log(error);
    });
}

function editSurvey2(SurveyId, SurveyCycle, SurveyReviewerId, SurveySubjectId, SurveyDateDue, SurveyBeenCompleted, SurveyDateCompleted){
    const editSurveyApiUrl="https://localhost:5001/api/Survey";

    fetch(editSurveyApiUrl, {
        method: "PUT", 
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            surveyId: SurveyId,
            cycle: SurveyCycle,
            reviewerEmpId: SurveyReviewerId,
            subjectEmpId: SurveySubjectId,
            dateDue: SurveyDateDue,
            beenCompleted: SurveyBeenCompleted,
            dateCompleted: SurveyDateCompleted
        })
    })
    .then((response)=>{
        console.log(response);
        window.location.href = "admin-tasks.html?userId="+userId;
    })
}