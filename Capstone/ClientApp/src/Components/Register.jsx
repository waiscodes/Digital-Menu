import React, { useState }from 'react'

const Register = () => {
  [resName, setResName] = useState();
  [resUserName, setResUsername] = useState();
  [resLocation, setResLocation] = useState();
  [email, setEmail] = useState();
  [password, setPassword] = useState();

  return (
    <>
      <form>
        <h3>Register Restaurant</h3>
      </form>
    </>
  );
}