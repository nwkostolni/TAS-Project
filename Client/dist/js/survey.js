//get url
const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
//remove user from url and put in global variable
var userId = urlParams.get('userId');
//remove subject from url and put in global variable
var subjectId = urlParams.get('subjectId');
//remove survey id from url and put in global variable
var surveyId = urlParams.get('surveyId');


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

function getCloseButton(){
    let html = "<a class=\"btn btn-primary btn-block\" href=\"task-list.html?userId="+userId+"\">Close without Saving</a>"; 
    document.getElementById("closeWithoutSaving").innerHTML=html; 
}

function getSubjectName(){
    const allEmployeesApiUrl = "https://localhost:5001/api/Employee";

    fetch(allEmployeesApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html="";
        json.forEach((Employee)=>{
            if(Employee.empId==subjectId){
                html += "<h1 class=\"mt-4\">Survey for "+Employee.empFirst+" "+Employee.empLast+"</h1> ";
            }
        })
        document.getElementById("surveyFor").innerHTML=html; 
    }).catch(function(error){
        console.log(error);
    });
}

function getQuestions(){
    const allQuestionsApiUrl = "https://localhost:5001/api/Question";

    fetch(allQuestionsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let html = "<tr>";
        let i = 0;
        json.forEach((Question)=>{
            if(Question.allowMultipleAnswers==true){
                html +="<td>" + Question.qstText + "</td>";
                html +="<td><label class=\"tab\">Never</label><input class=\"custom-radio\" name=\"a"+i+"\" type=\"radio\" id=\"never\" value=\"1\" /><label class=\"tab\">Rarely</label><input class=\"custom-radio\" name=\"a"+i+"\" type=\"radio\" id=\"rarely\" value=\"2\" /><label class=\"tab\">Sometimes</label><input class=\"custom-radio\" name=\"a"+i+"\" type=\"radio\" id=\"sometimes\" value=\"3\" /><label class=\"tab\">Often</label><input class=\"custom-radio\" name=\"a"+i+"\" type=\"radio\" id=\"often\" value=\"4\" /><label class=\"tab\">Always</label><input class=\"custom-radio\" name=\"a"+i+"\" type=\"radio\" id=\"always\" value=\"5\" /></td>";
                html += "</tr>";
                html += "<tr>";
                i++;
            }
            else{
                html +="<td>" + Question.qstText + "</td>";
                html +="<td><input class=\"form-control py-4\" id=\"a"+i+"\" name=\"openEnded\" type=\"text\" placeholder=\"Share your thoughts...\" /></td>";
                html += "</tr>";
                html += "<tr>";
                i++;
            }
        })
        html += "</tr>";
        document.getElementById("questionTable").innerHTML=html; 
    }).catch(function(error){
        console.log(error);
    });
}

var globalAnsId="";
function getGlobalAnsId(){
    const allAnswersApiUrl = "https://localhost:5001/api/Answer";

    fetch(allAnswersApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        json.forEach((Answer)=>{
            globalAnsId=Answer.ansId;
        })
        globalAnsId+=1;
    }).catch(function(error){
        console.log(error);
    });
}

function saveResponses(){
    var answerResponses = [];
    var i=0;
    var x =document.getElementsByName("openEnded");
    var flip = false;
    while(i<58){
        for (j = 0; j < x.length; j++) {
            if (x[j].id == ("a"+i)) {
              flip = true;
            }
        }
        if(flip){
            if(document.getElementById("a"+i).value ==null){
                alert("Please answer all questions before submitting.");
                break;
            }
            answerResponses[i] = {
                AnsId: (parseInt(globalAnsId)+i),
                AnsNumeric: null,
                AnsText: document.getElementById("a"+i).value,
                SurveyId: parseInt(surveyId),
                InputChoiceId: 6,
                QstId: (i+1)
            };
            i++;
            flip=false;
        }
        else{
            if(document.querySelector('input[name=a'+i+']:checked') ==null){
                alert("Please answer all questions before submitting.");
                break;
            }
            var first =document.querySelector('input[name=a'+i+']:checked').value;
            var second = parseInt(first);
            answerResponses[i] = {
            AnsId: (parseInt(globalAnsId)+i),
            AnsNumeric: second,
            AnsText: null,
            SurveyId: parseInt(surveyId),
            InputChoiceId: second,
            QstId: (i+1)
            };
            i++;
        }
    }
    saveResponses2(answerResponses);
} 
function saveResponses2(answerResponses){
    answerResponses.forEach(element => {
        const allAnswersApiUrl = "https://localhost:5001/api/Answer";
        fetch(allAnswersApiUrl, {
            method: "POST",
            headers: {
                "Accept": 'application/json',
                "Content-Type": 'application/json'
            },
            body: JSON.stringify({
                AnsId: element.AnsId,
                AnsNumeric: element.AnsNumeric,
                AnsText: element.AnsText,
                SurveyId: element.SurveyId,
                InputChoiceId: element.InputChoiceId,
                QstId: element.QstId
            })
        })
        .then((response)=>{
            console.log(response);
            if(element.QstId==58){
                completeSurvey();
            }
        });
    })
}

function completeSurvey(){
    const allSurveysApiUrl = "https://localhost:5001/api/Survey";

    fetch(allSurveysApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        json.forEach((Survey)=>{
            if(Survey.surveyId==surveyId){
                const SurveyId = Survey.surveyId;
                const SurveyCycle = Survey.cycle;
                const SurveyReviewerId= Survey.reviewerEmpId;
                const SurveySubjectId= Survey.subjectEmpId;
                var SurveyDateDue= new Date(Survey.dateDue).toJSON();

                const SurveyBeenCompleted = new Boolean(true);

                var SurveyDateCompleted = new Date().toJSON();

                completeSurvey2(SurveyId, SurveyCycle, SurveyReviewerId, SurveySubjectId, SurveyDateDue, SurveyBeenCompleted, SurveyDateCompleted);
            }
        })
    }).catch(function(error){
        console.log(error);
    });
}

function completeSurvey2(SurveyId, SurveyCycle, SurveyReviewerId, SurveySubjectId, SurveyDateDue, SurveyBeenCompleted, SurveyDateCompleted){
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
        window.location.href = "task-list.html?userId="+userId;
    })
}