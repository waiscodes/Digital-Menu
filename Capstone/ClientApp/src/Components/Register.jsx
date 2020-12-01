import React, { useState }from 'react'

const Register = () => {
  const [resName, setResName] = useState();
  const [resUserName, setResUsername] = useState();
  const [resLocation, setResLocation] = useState();
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  return (
    <>
      <form>
        <h3>Register Restaurant</h3>
        <div className="form-group">
          <label htmlFor="resName">Restaurant Name</label>
          <input type="text" name="resName" id="resName"/>
        </div>
        <div className="form-group">
          <label htmlFor="resUsername">Restaurant Username</label>
          <input type="text" name="resUsername" id="resUsername"/>
        </div>
        <div className="form-group">
          <label htmlFor="resLocation">Restaurant Location</label>
          <input type="text" name="resLocation" id="resLocation"/>
        </div>
        <div className="form-group">
          <label htmlFor="email">Email</label>
          <input type="email" name="email" id="email"/>
        </div>
        <div className="form-group">
          <label htmlFor="password">password</label>
          <input type="password" name="password" id="password"/>
        </div>
      </form>
    </>
  );
}

export default Register;