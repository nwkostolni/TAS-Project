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
    let html = "<a class=\"small text-white stretched-link\" href=\"assign-survey.html?userId="+userId+"\"></a>";
    document.getElementById("assignSurveyButton").innerHTML=html; 
}

function getSurveys(){
    const allSurveysApiUrl = "https://localhost:5001/api/Survey";

    fetch(allSurveysApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<tr>";
        json.forEach((Survey)=>{
            html +="<td>" + Survey.surveyId + "</td>";
            html +="<td>" + Survey.cycle + "</td>";
            var newDate= new Date(Survey.dateDue);
            Date.prototype.addHours = function(h) {
                this.setTime(this.getTime() + (h*60*60*1000));
                return this;
            }
            var newDate = newDate.addHours(6);
            var day =newDate.getDate();
            var month = newDate.getMonth()+1;
            var year =newDate.getFullYear();
            html +="<td>" + month+"/"+day+"/"+year + "</td>";
            if(Survey.beenCompleted==1){
                html +="<td><span class=\"material-icons\">check_box</span></td>";
            }
            else{
                html +="<td><span class=\"material-icons\">check_box_outline_blank</span></td>";
            }
            if(Survey.dateCompleted==null){
                html +="<td></td>";
            }
            else{
                var newDate2= new Date(Survey.dateCompleted);
                Date.prototype.addHours = function(h) {
                    this.setTime(this.getTime() + (h*60*60*1000));
                    return this;
                }
                var newDate2 = newDate2.addHours(6);
                var day =newDate2.getDate();
                var month = newDate2.getMonth()+1;
                var year =newDate2.getFullYear();
                html +="<td>" + month+"/"+day+"/"+year + "</td>";
            }
            html +="<td>" + Survey.reviewerEmpId + "</td>";
            html +="<td>" + Survey.subjectEmpId + "</td>";
            html +="<td><span class=\"material-icons cursor\" onclick=\"editSurvey("+Survey.surveyId+")\">edit</span><text>  </text><span class=\"material-icons cursor\" onclick=\"deleteSurvey("+Survey.surveyId+")\">delete</span></td>";
            html += "</tr>";
            html += "<tr>";
        })
        html += "</tr>";
        document.getElementById("surveyTable").innerHTML=html; 
    }).catch(function(error){
        console.log(error);
    });
}

function editSurvey(editId){
    window.location.href = "editSurvey.html?userId=" + userId + "&editId=" +editId;
}

function deleteSurvey(editId){
    if (confirm('Are you sure you want to delete this assignment?')) {
        // Delete
        deleteSurveyConfirmed(editId);
        location.reload();
        alert("Assignment has been deleted.");
    } 
    else {
        // Cancel
    }
}

function deleteSurveyConfirmed(editId){
    const deleteSurveyApiUrl="https://localhost:5001/api/Survey";

    fetch(deleteSurveyApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json'
        },
        body: JSON.stringify({
            surveyId: editId
        })
    })
    .then((response)=>{
        console.log(response);
    })
}