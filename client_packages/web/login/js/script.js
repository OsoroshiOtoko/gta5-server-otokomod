const wrapper = document.querySelector(".wrapper");
const loginLink = document.querySelector(".login-link");
const registerLink = document.querySelector(".register-link");

const logBtn = document.getElementById("logBtn");
const regBtn = document.getElementById("regBtn");

const logEmail = document.getElementById("logEmail");
const logPassword = document.getElementById("logPassword");

const regEmail = document.getElementById("regEmail");
const regPassword = document.getElementById("regPassword");
const firstName = document.getElementById("first-name");
const lastName = document.getElementById("last-name");

const alert = document.getElementById("alert");

var chek = false;


registerLink.addEventListener("click", ()=> 
{
  wrapper.classList.add('active');
});

loginLink.addEventListener("click", ()=> 
{
  wrapper.classList.remove('active');
});


//validation
logBtn.addEventListener("click", (e)=> 
{
  e.preventDefault();

  if(!logEmail.value.match(/^[^ ]+@[a-z]+\.[a-z]{2,3}/))
  {
    logEmail.style.border = "2px solid #FF0000";
    chek = false;
  }
  else 
  {
    logEmail.style.border = "none";
    chek = true;
  }


  if(logPassword.value.match(/[а-яА-Я]/) || logPassword.value.length < 8)
  {
    logPassword.style.border = "2px solid #FF0000";
    chek = false;
  }
  else 
  {
    logPassword.style.border = "none";
    chek = true;
  }


  if(chek)
  {
    alert.textContent = "Chek";
  } 
});

regBtn.addEventListener("click", (e)=> 
{
  e.preventDefault();

  if(!firstName.value.match(/[A-Z]+[a-z]{3,}/))
  {
    firstName.style.border = "2px solid #FF0000";
    chek = false;
  }
  else 
  {
    firstName.style.border = "none";
    chek = true;
  }


  if(!lastName.value.match(/[A-Z]+[a-z]{3,}/))
  {
    lastName.style.border = "2px solid #FF0000";
    chek = false;
  }
  else 
  {
    lastName.style.border = "none";
    chek = true;
  }


  if(!regEmail.value.match(/^[^ ]+@[a-z]+\.[a-z]{2,3}/))
  {
    regEmail.style.border = "2px solid #FF0000";
    chek = false;
  }
  else 
  {
    regEmail.style.border = "none";
    chek = true;
  }


  if(regPassword.value.match(/[а-яА-Я]/) || regPassword.value.length < 8)
  {
    regPassword.style.border = "2px solid #FF0000";
    chek = false;
  }
  else 
  {
    regPassword.style.border = "none";
    chek = true;
  }


  if(chek)
  {
    /*alert.textContent = "Chek";*/
    mp.trigger('authRegister', firstName.value, lastName.value, regEmail.value, regPassword.value);
  } 
});
