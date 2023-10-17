import React, {FC} from 'react';

interface AuthProps{
    reveal: boolean,
    children: JSX.Element,
}

const AuthPopup = (props: AuthProps) => {
    
    return (
        <>
        {props.reveal ? 
            <div className="z-10 flex justify-center align-middle items-center">
                <div className ="fixed top-96 z-10 rounded-lg">
                    {props.children}
                </div>
            </div> 

            : ""
        }
        </>
    );
}

export default AuthPopup;