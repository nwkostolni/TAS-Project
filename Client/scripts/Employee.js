function getEmployees(){
    const EmployeeApiUrl = "https://localhost:5001/api/Employee";

    fetch(EmployeeApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){

        json.forEach((Employee)=>{
            //let html=Employee.empId;
            document.getElementById("EmpId").textContent=Employee.empId;
            let html1=Employee.empFirst;
            document.getElementById("EmpFirst").innerHTML=html1;
            let html2=Employee.empLast;
            document.getElementById("EmpLast").innerHTML=html2;
            let html3=Employee.empId;
            document.getElementById("EmpEmail").innerHTML=html3;
            let html4=Employee.empDept;
            document.getElementById("EmpDept").innerHTML=html4;
            let html5=Employee.empLevel;
            document.getElementById("EmpLevel").innerHTML=html5;
        })
    }).catch(function(error){
        console.log(error);
    });
}