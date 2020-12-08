import React, { useState, useEffect } from "react";
import { connect } from "react-redux";
import { Redirect } from "react-router-dom";
import axios from "axios";
import "../css/Create.css";

const Create = (props) => {
  const [response, setResponse] = useState([]);
  const [catResponse, setCatResponse] = useState();
  const [category, setCategory] = useState("");
  const [user, setUser] = useState();
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [description, setDescription] = useState("");
  const [waitTime, setWaitTime] = useState("");
  const [ingredients, setIngredients] = useState("");
  const [calories, setCalories] = useState("");
  const [halal, setHalal] = useState("");
  const [img, setImg] = useState();
  const [loading, setLoading] = useState(true);

  const handleFieldChange = (e) => {
    switch (e.target.id) {
      case "category":
        setCategory(e.target.value);
        break;
      case "name":
        setName(e.target.value);
        break;
      case "price":
        setPrice(e.target.value);
        break;
      case "description":
        setDescription(e.target.value);
        break;
      case "wait-time":
        setWaitTime(e.target.value);
        break;
      case "ingredients":
        setIngredients(e.target.value);
        break;
      case "calories":
        setCalories(e.target.value);
        break;
      case "halal":
        setHalal(e.target.value);
        break;
      case "img":
        setImg(e.target.files[0]);
        break;
    }
  };

  const renderDropdown = (catResponse) => {
    return (
      <>
        {catResponse.map((cat) => {
          return (
            <>
              <option key={cat.id} value={cat.id}>
                {cat.name}
              </option>
            </>
          );
        })}
      </>
    );
  };

  const populateCatDropdown = async () => {
    await axios({
      method: "get",
      url: "Values/ListCat",
      params: {
        username: user,
      },
    }).then((response) => {
      setCatResponse(response.data);
      setLoading(false);
    });
  };

  useEffect(() => {
    populateCatDropdown();
  }, [loading]);

  let content = loading ? <p>Loading...</p> : renderDropdown(catResponse);

  const handleSubmit = (e) => {
    e.preventDefault();
    setLoading(true);

    const formData = new FormData();
    formData.append("file", img);

    axios({
      method: "post",
      url: "Values/CreateMenu",
      headers: { "Content-Type": "multipart/form-data" },
      data: formData,
      params: {
        name: name,
        description: description,
        price: price,
        waitTimeMins: waitTime,
        ingredients: ingredients,
        calories: calories,
        halal: halal,
        catID: category,
        resUsername: user,
      },
    })
      .then((res) => {
        setLoading(false);
        setResponse(res.data);
      })
      .catch((err) => {
        setLoading(false);
        setResponse(err.response.data);
      });
  };

  return (
    <>
      <section className='create-section'>
        <h3>Create</h3>
        <form onSubmit={handleSubmit}>
          <div className='form-group'>
            <label htmlFor='category'>Category</label>
            <select
              name='category'
              id='category'
              onChange={handleFieldChange}
              required
            >
              <option value='none' selected disabled hidden>
                Select an Option
              </option>
              {content}
            </select>
          </div>
          <div className='form-group'>
            <label htmlFor='name'>Name</label>
            <input
              type='text'
              name='name'
              id='name'
              onChange={handleFieldChange}
              required
            />
          </div>
          <div className='form-group'>
            <label htmlFor='price'>Price</label>
            <input
              type='number'
              name='price'
              id='price'
              onChange={handleFieldChange}
              required
            />
          </div>
          <div className='form-group'>
            <label htmlFor='description'>Description</label>
            <input
              type='text'
              name='description'
              id='description'
              onChange={handleFieldChange}
              required
            />
          </div>
          <div className='form-group'>
            <label htmlFor='wait-time'>Wait Time (Minutes)</label>
            <input
              type='number'
              name='wait-time'
              id='wait-time'
              onChange={handleFieldChange}
              required
            />
          </div>
          <div className='form-group'>
            <label htmlFor='Ingredients'>Ingredients</label>
            <input
              type='text'
              name='ingredients'
              id='ingredients'
              onChange={handleFieldChange}
              required
            />
          </div>
          <div className='form-group'>
            <label htmlFor='calories'>Calories</label>
            <input
              type='number'
              name='calories'
              id='calories'
              onChange={handleFieldChange}
              required
            />
          </div>
          <div className='form-group'>
            <label htmlFor='halal'>Halal</label>
            <select
              name='halal'
              id='halal'
              onChange={handleFieldChange}
              required
            >
              <option value='none' selected disabled hidden>
                Select an Option
              </option>
              <option value='true'>Halal</option>
              <option value='false'>Non-Halal</option>
            </select>
          </div>
          <div className='form-group'>
            <label htmlFor='img'>Image</label>
            <input
              type='file'
              id='img'
              name='img'
              accept='image/*'
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
};

export default connect((state) => {
  return {
    activeUser: state,
  };
})(Create);
