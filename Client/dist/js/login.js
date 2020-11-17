function getEmployees(){
	const EmployeeApiUrl = "https://localhost:5001/api/Employee";


    fetch(EmployeeApiUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){
		const email =(document.getElementById("inputEmailAddress").value).toLowerCase();
		const password = document.getElementById("inputPassword").value;
		let result;
        json.forEach((Employee)=>{
			let dataEmail = (Employee.empEmail).toLowerCase();
			let dataPassword = Employee.password;
            if(dataEmail == email){
				if(dataPassword == password){
					window.location.href="index.html?userId="+Employee.empId;
				}
			}
		})
		let html="<text style=\"color:red;\">Incorrect Email or Password</text>";
		document.getElementById("errorMessage").innerHTML=html;
    }).catch(function(error){
        console.log(error);
    });
}