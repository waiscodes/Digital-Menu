import React, { useState } from "react";
import axios from "axios";

const Login = () => {
  const [response, setResponse] = useState([]);
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [waiting, setWaiting] = useState("");

  const handleFieldChange = (e) => {
    switch (e.target.id) {
      case "email":
        setEmail(e.target.value);
        break;
      case "password":
        setPassword(e.target.value);
        break;
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setWaiting(true);

    axios({
      method: "post",
      url: "Values/Login",
      headers: { "Content-Type": "multipart/form-data" },
      params: {
        email: email,
        password: password,
      },
    })
      .then((res) => {
        setWaiting(false);
        setResponse(res.data);
      })
      .catch((err) => {
        setWaiting(false);
        setResponse(err.response.data);
      });
  };

  return (
    <>
      <form onSubmit={handleSubmit}>
        <h3>Login</h3>
        <div className='form-group'>
          <label htmlFor='email'>Email</label>
          <input
            type='email'
            name='email'
            id='email'
            onChange={handleFieldChange}
          />
        </div>
        <div className='form-group'>
          <label htmlFor='password'>password</label>
          <input
            type='password'
            name='password'
            id='password'
            onChange={handleFieldChange}
          />
        </div>
        <div>
          <input type='submit' value='Submit' />
        </div>
      </form>
    </>
  );
};

export default Login;
