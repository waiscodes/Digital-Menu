import React, { useState }from 'react'

const Login = () => {
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();

  return (
    <>
      <form>
        <h3>Login Restaurant</h3>
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

export default Login;