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

function getTables(){
    const allQuestionsApiUrl = "https://localhost:5001/api/Question";
    const allSurveysApiUrl = "https://localhost:5001/api/Survey";
    const allAnswersApiUrl = "https://localhost:5001/api/Answer";
    var questionArray= new Array();
    var surveyArray= new Array();
    var answerArray= new Array();
    fetch(allQuestionsApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        var i =0;
        json.forEach((Question)=>{
            questionArray[i] = {
            qstId: Question.qstId,
            qstText: Question.qstText,
            qstRequired: Question.qstRequired,
            ansRequired: Question.ansRequired,
            allowMultipleAnswers: Question.allowMultipleAnswers,
            qstCategory: Question.qstCategory,
            inputTypeId: Question.inputTypeId
            };
            i++;
        })
        console.log(questionArray[5].qstText);
    }).then(function(){
        console.log(questionArray[5].qstText);
        fetch(allSurveysApiUrl).then(function(response){
            console.log(response);
            return response.json();
        }).then(function(json){
            var i =0;
            json.forEach((Survey)=>{
                if(Survey.subjectEmpId == userId && Survey.beenCompleted==true){
                    surveyArray[i] = {
                    surveyId: Survey.surveyId,
                    cycle: Survey.cycle,
                    reviewerEmpId: Survey.reviewerEmpId,
                    subjectEmpId: Survey.subjectEmpId,
                    dateDue: Survey.dateDue,
                    beenCompleted: Survey.beenCompleted,
                    dateCompleted: Survey.dateCompleted
                    };
                    i++;
                }
            })
        }).then(function(){
            console.log(surveyArray[0].surveyId);
            console.log(questionArray[5].qstText);
            fetch(allAnswersApiUrl).then(function(response){
                console.log(response);
                return response.json();
            }).then(function(json){
                var i =0;
                json.forEach((Answer)=>{
                        answerArray[i] = {
                            ansId: Answer.ansId,
                            ansNumeric: Answer.ansNumeric,
                            ansText: Answer.ansText,
                            surveyId: Answer.surveyId,
                            inputChoiceId: Answer.inputChoiceId,
                            qstId: Answer.qstId
                        };
                        i++;
                })
                console.log(answerArray[7].ansId);
            }).then(function(){
            //Collaboration Table 1
            let html = "<tr>";
            var i=0;
            var peerCount=0;
            var peerSum=0;
            while(i<7){
                html +="<td>" + questionArray[i].qstText + "</td>";
                surveyArray.forEach(Survey => {
                    if(Survey.reviewerEmpId==userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                html +="<td>"+Answer.ansNumeric+"</td>";
                            }
                        });
                    }
                    if(Survey.reviewerEmpId !== userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                peerSum+=Answer.ansNumeric;
                                peerCount++;
                            }
                        });
                    }
                });
                var peerAvg= peerSum/peerCount;
                html +="<td>"+Math.round(peerAvg)+"</td>";
                html += "</tr>";
                i++;
            }
            document.getElementById("collaboration1").innerHTML=html; 
            //Collaboration Table 2
            html = "<tr>";
            html +="<td>" + questionArray[7].qstText + "</td>";
            surveyArray.forEach(Survey => {
                answerArray.forEach(Answer => {
                    if(Survey.surveyId==Answer.surveyId && questionArray[7].qstId==Answer.qstId){
                        html +="<td>"+Answer.ansText+"</td>";
                    }
                });
                html += "</tr>";
                html += "<tr>";
                html +="<td></td>";
            });
            html +="<td></td>";
            html += "</tr>";
            document.getElementById("collaboration2").innerHTML=html;
            //Communication Table 1
            html = "<tr>";
            var i=8;
            var peerCount=0;
            var peerSum=0;
            while(i<15){
                html +="<td>" + questionArray[i].qstText + "</td>";
                surveyArray.forEach(Survey => {
                    if(Survey.reviewerEmpId==userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                html +="<td>"+Answer.ansNumeric+"</td>";
                            }
                        });
                    }
                    if(Survey.reviewerEmpId !== userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                peerSum+=Answer.ansNumeric;
                                peerCount++;
                            }
                        });
                    }
                });
                var peerAvg= peerSum/peerCount;
                html +="<td>"+Math.round(peerAvg)+"</td>";
                html += "</tr>";
                html += "<tr>";
                i++;
            }
            html += "</tr>";
            document.getElementById("communication1").innerHTML=html; 
            //Communication Table 2
            html = "<tr>";
            html +="<td>" + questionArray[15].qstText + "</td>";
            surveyArray.forEach(Survey => {
                answerArray.forEach(Answer => {
                    if(Survey.surveyId==Answer.surveyId && questionArray[15].qstId==Answer.qstId){
                        html +="<td>"+Answer.ansText+"</td>";
                    }
                });
                html += "</tr>";
                html += "<tr>";
                html +="<td></td>";
            });
            html +="<td></td>";
            html += "</tr>";
            document.getElementById("communication2").innerHTML=html;
            //Customer Focus Table 1
            html = "<tr>";
            var i=16;
            var peerCount=0;
            var peerSum=0;
            while(i<23){
                html +="<td>" + questionArray[i].qstText + "</td>";
                surveyArray.forEach(Survey => {
                    if(Survey.reviewerEmpId==userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                html +="<td>"+Answer.ansNumeric+"</td>";
                            }
                        });
                    }
                    if(Survey.reviewerEmpId !== userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                peerSum+=Answer.ansNumeric;
                                peerCount++;
                            }
                        });
                    }
                });
                var peerAvg= peerSum/peerCount;
                html +="<td>"+Math.round(peerAvg)+"</td>";
                html += "</tr>";
                html += "<tr>";
                i++;
            }
            html += "</tr>";
            document.getElementById("customerfocus1").innerHTML=html; 
            //Customer Focus Table 2
            html = "<tr>";
            html +="<td>" + questionArray[23].qstText + "</td>";
            surveyArray.forEach(Survey => {
                answerArray.forEach(Answer => {
                    if(Survey.surveyId==Answer.surveyId && questionArray[23].qstId==Answer.qstId){
                        html +="<td>"+Answer.ansText+"</td>";
                    }
                });
                html += "</tr>";
                html += "<tr>";
                html +="<td></td>";
            });
            html +="<td></td>";
            html += "</tr>";
            document.getElementById("customerfocus2").innerHTML=html;
            //Productivity Table 1
            html = "<tr>";
            var i=24;
            var peerCount=0;
            var peerSum=0;
            while(i<31){
                html +="<td>" + questionArray[i].qstText + "</td>";
                surveyArray.forEach(Survey => {
                    if(Survey.reviewerEmpId==userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                html +="<td>"+Answer.ansNumeric+"</td>";
                            }
                        });
                    }
                    if(Survey.reviewerEmpId !== userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                peerSum+=Answer.ansNumeric;
                                peerCount++;
                            }
                        });
                    }
                });
                var peerAvg= peerSum/peerCount;
                html +="<td>"+Math.round(peerAvg)+"</td>";
                html += "</tr>";
                html += "<tr>";
                i++;
            }
            html += "</tr>";
            document.getElementById("productivity1").innerHTML=html; 
            //Productivity Table 2
            html = "<tr>";
            html +="<td>" + questionArray[31].qstText + "</td>";
            surveyArray.forEach(Survey => {
                answerArray.forEach(Answer => {
                    if(Survey.surveyId==Answer.surveyId && questionArray[31].qstId==Answer.qstId){
                        html +="<td>"+Answer.ansText+"</td>";
                    }
                });
                html += "</tr>";
                html += "<tr>";
                html +="<td></td>";
            });
            html +="<td></td>";
            html += "</tr>";
            document.getElementById("productivity2").innerHTML=html;
            //Integrity Table 1
            html = "<tr>";
            var i=32;
            var peerCount=0;
            var peerSum=0;
            while(i<39){
                html +="<td>" + questionArray[i].qstText + "</td>";
                surveyArray.forEach(Survey => {
                    if(Survey.reviewerEmpId==userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                html +="<td>"+Answer.ansNumeric+"</td>";
                            }
                        });
                    }
                    if(Survey.reviewerEmpId !== userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                peerSum+=Answer.ansNumeric;
                                peerCount++;
                            }
                        });
                    }
                });
                var peerAvg= peerSum/peerCount;
                html +="<td>"+Math.round(peerAvg)+"</td>";
                html += "</tr>";
                html += "<tr>";
                i++;
            }
            html += "</tr>";
            document.getElementById("integrity1").innerHTML=html; 
            //Integrity Table 2
            html = "<tr>";
            html +="<td>" + questionArray[39].qstText + "</td>";
            surveyArray.forEach(Survey => {
                answerArray.forEach(Answer => {
                    if(Survey.surveyId==Answer.surveyId && questionArray[39].qstId==Answer.qstId){
                        html +="<td>"+Answer.ansText+"</td>";
                    }
                });
                html += "</tr>";
                html += "<tr>";
                html +="<td></td>";
            });
            html +="<td></td>";
            html += "</tr>";
            document.getElementById("integrity2").innerHTML=html;
            //Problem Solving Table 1
            html = "<tr>";
            var i=40;
            var peerCount=0;
            var peerSum=0;
            while(i<47){
                html +="<td>" + questionArray[i].qstText + "</td>";
                surveyArray.forEach(Survey => {
                    if(Survey.reviewerEmpId==userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                html +="<td>"+Answer.ansNumeric+"</td>";
                            }
                        });
                    }
                    if(Survey.reviewerEmpId !== userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                peerSum+=Answer.ansNumeric;
                                peerCount++;
                            }
                        });
                    }
                });
                var peerAvg= peerSum/peerCount;
                html +="<td>"+Math.round(peerAvg)+"</td>";
                html += "</tr>";
                html += "<tr>";
                i++;
            }
            html += "</tr>";
            document.getElementById("problemsolving1").innerHTML=html; 
            //Problem Solving Table 2
            html = "<tr>";
            html +="<td>" + questionArray[47].qstText + "</td>";
            surveyArray.forEach(Survey => {
                answerArray.forEach(Answer => {
                    if(Survey.surveyId==Answer.surveyId && questionArray[47].qstId==Answer.qstId){
                        html +="<td>"+Answer.ansText+"</td>";
                    }
                });
                html += "</tr>";
                html += "<tr>";
                html +="<td></td>";
            });
            html +="<td></td>";
            html += "</tr>";
            document.getElementById("problemsolving2").innerHTML=html;
            //Self Leadership Table 1
            html = "<tr>";
            var i=48;
            var peerCount=0;
            var peerSum=0;
            while(i<55){
                html +="<td>" + questionArray[i].qstText + "</td>";
                surveyArray.forEach(Survey => {
                    if(Survey.reviewerEmpId==userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                html +="<td>"+Answer.ansNumeric+"</td>";
                            }
                        });
                    }
                    if(Survey.reviewerEmpId !== userId){
                        answerArray.forEach(Answer => {
                            if(Survey.surveyId==Answer.surveyId && questionArray[i].qstId==Answer.qstId){
                                peerSum+=Answer.ansNumeric;
                                peerCount++;
                            }
                        });
                    }
                });
                var peerAvg= peerSum/peerCount;
                html +="<td>"+Math.round(peerAvg)+"</td>";
                html += "</tr>";
                html += "<tr>";
                i++;
            }
            html += "</tr>";
            document.getElementById("selfleadership1").innerHTML=html; 
            //Self Leadership Table 2
            html = "<tr>";
            html +="<td>" + questionArray[55].qstText + "</td>";
            surveyArray.forEach(Survey => {
                answerArray.forEach(Answer => {
                    if(Survey.surveyId==Answer.surveyId && questionArray[55].qstId==Answer.qstId){
                        html +="<td>"+Answer.ansText+"</td>";
                    }
                });
                html += "</tr>";
                html += "<tr>";
                html +="<td></td>";
            });
            html +="<td></td>";
            html += "</tr>";
            document.getElementById("selfleadership2").innerHTML=html;
            //Final Questions Table 1
            html = "<tr>";
            html +="<td>" + questionArray[56].qstText + "</td>";
            surveyArray.forEach(Survey => {
                answerArray.forEach(Answer => {
                    if(Survey.surveyId==Answer.surveyId && questionArray[56].qstId==Answer.qstId){
                        html +="<td>"+Answer.ansText+"</td>";
                    }
                });
                html += "</tr>";
                html += "<tr>";
                html +="<td></td>";
            });
            html +="<td></td>";
            html += "</tr>";
            html += "<tr>";
            html +="<td>" + questionArray[57].qstText + "</td>";
            surveyArray.forEach(Survey => {
                answerArray.forEach(Answer => {
                    if(Survey.surveyId==Answer.surveyId && questionArray[57].qstId==Answer.qstId){
                        html +="<td>"+Answer.ansText+"</td>";
                    }
                });
                html += "</tr>";
                html += "<tr>";
                html +="<td></td>";
            });
            html +="<td></td>";
            html += "</tr>";
            document.getElementById("finalquestions").innerHTML=html;
            })
        })
    });
}

function getPieChart(){
    const allSurveysApiUrl = "https://localhost:5001/api/Survey";
    fetch(allSurveysApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
        let completed = 0;
        let incomplete = 0;
        json.forEach((Survey)=>{
            if(Survey.subjectEmpId==userId && Survey.beenCompleted==true){
                completed ++;
            }
            if(Survey.subjectEmpId==userId && Survey.beenCompleted==false){
                incomplete ++;
                document.getElementById("incompleteMessage").innerHTML=incomplete;
                document.getElementById("totalMessage").innerHTML=incomplete+completed;
            }
        })
    });
}