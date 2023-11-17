import React, {useState} from 'react';

const Profile = () => {
    const [name, setName] = useState("PROFILE");

    return (
        <div>{name}</div>
    );
}

export default Profile;