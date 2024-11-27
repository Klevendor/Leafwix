const USERNAME_REGEX = /^[a-zA-Z][a-zA-Z0-9-_\s]{2,30}$/;
const PASSWORD_REGEX = /[\w#$%!? \p{L}]{6,20}/u;
const EMAIL_REGEX = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/u;

export const ValidationService =  {
    async validateLoginForm(email,password) {
       let validationResult = {
        isValid : false,
        error: ""
       }

        if(email === "" || password === "")
        {
            validationResult.error = "All fields must be completed"
            return validationResult
        }
        if(!EMAIL_REGEX.test(email))
        {
            validationResult.error = "Invalid email"
            return validationResult
        }
        if(!PASSWORD_REGEX.test(password))
        {
            validationResult.error = "Password length should be from 6 to 20 characters"
            return validationResult
        }
            
        validationResult.isValid = true
        return validationResult

      },

    async validateRegisterForm(username, email, password, confirmPassword) {
        let validationResult = {
         isValid : false,
         error: ""
        }
 
        if(email === "" || password === "" || username === "" || confirmPassword === "")
        {
             validationResult.error = "All fields must be completed"
             return validationResult
        }
        if(password != confirmPassword)
        {
            validationResult.error = "Password and confirm password not match"
            return validationResult
        }
        if(!USERNAME_REGEX.test(username))
            {
                 validationResult.error = "Username must contain only english letters, numbers and _"
                 return validationResult
            }
        if(!EMAIL_REGEX.test(email))
        {
             validationResult.error = "Invalid email"
             return validationResult
        }
        if(!PASSWORD_REGEX.test(password))
        {
             validationResult.error = "Password length should be from 6 to 20 characters"
             return validationResult
        }
             
         validationResult.isValid = true
         return validationResult
 
       },

    async validateForgotPasswordForm(email) {
        let validationResult = {
         isValid : false,
         error: ""
        }
 
        if(email === "")
        {
             validationResult.error = "Enter your email"
             return validationResult
        }
        if(!EMAIL_REGEX.test(email))
        {
             validationResult.error = "Invalid email"
             return validationResult
        }
             
         validationResult.isValid = true
         return validationResult
 
       },
    
    async validateResetPasswordForm(password, confirmPassword) {
        let validationResult = {
         isValid : false,
         error: ""
        }
 
        if(password === "" || confirmPassword === "")
        {
             validationResult.error = "All fields must be completed"
             return validationResult
        }
        if(password != confirmPassword)
        {
            validationResult.error = "Password and confirm password not match"
            return validationResult
        }
        if(!PASSWORD_REGEX.test(password))
        {
             validationResult.error = "Password length should be from 6 to 20 characters"
             return validationResult
        }
             
         validationResult.isValid = true
         return validationResult
 
       },
}
