interface Errors{
    email: string[];
    password: string[];
}

const EMAIL_REGEX = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
const PW_REGEX = /^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/;

export const LoginValidator = (email: string, pw: string): Errors => {
        const errors = <Errors>{};
        errors.email = []
        errors.password = []

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
    
        return errors;

}