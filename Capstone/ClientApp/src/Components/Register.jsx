import React, { useState } from "react";
import { connect } from "react-redux";
import aActiveUser from "../Actions/aActiveUser";
import axios from "axios";
import { Redirect } from "react-router-dom";
import "../css/Register.css";

const Register = (props) => {
  const [response, setResponse] = useState([]);
  const [resName, setResName] = useState();
  const [resUsername, setResUsername] = useState();
  const [resLocation, setResLocation] = useState();
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [waiting, setWaiting] = useState("");

  const handleFieldChange = (e) => {
    switch (e.target.id) {
      case "resName":
        setResName(e.target.value);
        break;
      case "resUsername":
        setResUsername(e.target.value);
        break;
      case "resLocation":
        setResLocation(e.target.value);
        break;
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
      url: "Values/Register",
      headers: { "Content-Type": "multipart/form-data" },
      params: {
        resName: resName,
        resUsername: resUsername,
        email: email,
        password: password,
        resLocation: resLocation,
      },
    })
      .then((res) => {
        setWaiting(false);
        setResponse(res.data);
        props.dispatch(aActiveUser(res.data));
      })
      .catch((err) => {
        setWaiting(false);
        setResponse(err.response.data);
      });
  };

  if (props.aActiveUser == undefined) {
    return (
      <>
        <section className='register-section'>
          <h3>Register</h3>
          <form onSubmit={handleSubmit}>
            <div className='form-group'>
              <label htmlFor='resName'>Restaurant Name</label>
              <input
                type='text'
                name='resName'
                id='resName'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='resUsername'>Restaurant Username</label>
              <input
                type='text'
                name='resUsername'
                id='resUsername'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='resLocation'>Restaurant Location</label>
              <input
                type='text'
                name='resLocation'
                id='resLocation'
                onChange={handleFieldChange}
              />
            </div>
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
        </section>
      </>
    );
  } else if (
    props.aActiveUser !== undefined &&
    props.aActiveUser.username != undefined
  ) {
    return <Redirect to='/create' />;
  } else {
    return (
      <>
        <section className='register-section'>
          <h3>Register</h3>
          <form onSubmit={handleSubmit}>
            <div className='form-group'>
              <label htmlFor='resName'>Restaurant Name</label>
              <input
                type='text'
                name='resName'
                id='resName'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='resUsername'>Restaurant Username</label>
              <input
                type='text'
                name='resUsername'
                id='resUsername'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='resLocation'>Restaurant Location</label>
              <input
                type='text'
                name='resLocation'
                id='resLocation'
                onChange={handleFieldChange}
              />
            </div>
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
        </section>
      </>
    );
  }
};

export default connect((state) => {
  return {
    state: state,
  };
})(Register);
