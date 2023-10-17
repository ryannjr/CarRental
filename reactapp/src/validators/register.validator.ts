
interface Errors{
    firstName: string[]; 
    lastName: string[];
    email: string[];
    password: string[];
    confirmPassword: string[]
}

const EMAIL_REGEX = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const PW_REGEX = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/;
export const RegisterValidator = (fname: string, lname: string,
    email: string, pw: string, cpw: string): Errors => {

        const errors = <Errors>{};
        errors.firstName = []
        errors.lastName = []
        errors.email = []
        errors.password = []
        errors.confirmPassword = []

        // FIRST NAME FIELD VALIDATION
        if(!fname){
            errors.firstName.push("Field cannot be empty");
        } if(fname.length < 2){
            errors.firstName.push("Field must be greater than 2 characters");
        } if(/\d/.test(fname)){
            errors.firstName.push("Field cannot include digits");
        }
        
        // LAST NAME FIELD VALIDATION
        if(!lname){
            errors.lastName.push("Field cannot be empty");
        } if(lname.length < 2){
            errors.lastName.push("Field must be greater than 2 characters");
        } if(/\d/.test(lname)){
            errors.lastName.push("Field cannot include digits");
        }
        
        // EMAIL FIELD VALIDATION
        if(!email){
            errors.email.push("Field cannot be empty");
        } if(!EMAIL_REGEX.test(email)){
            errors.email.push("This is not a proper email format");
        }

        // PASSWORD FIELD VALIDATION
        
        if(!pw){
            errors.password.push("Field cannot be empty");
        } if(!PW_REGEX.test(pw)){
            errors.password.push("Password is not strong enough.");
        }
    
        if(!cpw) {
            errors.confirmPassword.push("Field cannot be empty");
        } if(pw !== cpw){
            errors.confirmPassword.push("Passwords do not match");
        }

        return errors;

}