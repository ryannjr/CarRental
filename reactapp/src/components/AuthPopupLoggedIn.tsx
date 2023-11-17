import React, {FC} from 'react';

interface AuthProps{
    reveal: boolean,
    children: JSX.Element,
}

const AuthPopupLoggedIn = (props: AuthProps) => {
    
    return (
        <>
        {props.reveal ? 
            <div className="z-10 flex">
                <div className ="z-10">
                    {props.children}
                </div>
            </div> 

            : ""
        }
        </>
    );
}

export default AuthPopupLoggedIn;