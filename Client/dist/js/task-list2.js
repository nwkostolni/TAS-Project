function managedEmployeeAlert(){
    alert("WARNING: You are now viewing another employee's data. All changes made on these pages will be permanent as if this employee had made them. \n TO RETURN TO YOUR PAGES: Use the browser's back button until your name appears in the top left corner of the page.");
}

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

function getSurveys(){
    const allSurveysApiUrl = "https://localhost:5001/api/Survey";

    fetch(allSurveysApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<tr>";
        json.forEach((Survey)=>{
            if(Survey.reviewerEmpId==userId){
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
                html +="<td id=\""+Survey.subjectEmpId+"\"></td>";
                if(Survey.beenCompleted==1){
                    html +="<td><span class=\"material-icons\">check_box</span></td>";
                }
                else{
                    html +="<td><span class=\"material-icons cursor\" onclick=\"goToSurvey("+Survey.subjectEmpId+", "+Survey.surveyId+")\">forward</span></td>";
                }
                html += "</tr>";
                html += "<tr>";
            }
        })
        html += "</tr>";
        document.getElementById("surveyTable").innerHTML=html; 
    }).catch(function(error){
        console.log(error);
    });
}

function getSubjectName(){
    const allEmployeesApiUrl = "https://localhost:5001/api/Employee";

    fetch(allEmployeesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        json.forEach((Employee)=>{
            if(document.getElementById(Employee.empId) !== null){
                var subjectName=(Employee.empFirst + " " + Employee.empLast);
                document.getElementById(Employee.empId).innerHTML=subjectName;
            }
        })
    }).catch(function(error){
        console.log(error);
    });
}

function goToSurvey(subjectEmpId, surveyId){
    window.location.href = "survey.html?userId=" + userId + "&subjectId=" +subjectEmpId + "&surveyId=" +surveyId;
}