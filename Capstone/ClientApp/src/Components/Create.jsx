import React, { useState } from "react";

const Create = () => {
  const [response, setResponse] = useState([]);
  const [category, setCategory] = useState("");
  const [user, setUser] = useState("");
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [description, setDescription] = useState("");
  const [waitTime, setWaitTime] = useState("");
  const [ingredients, setIngredients] = useState("");
  const [calories, setCalories] = useState("");
  const [halal, setHalal] = useState("");
  const [img, setImg] = useState();

  const handleFieldChange = (e) => {};

  const handleSubmit = (e) => {
    e.preventDefault();
  };

  return (
    <>
      <form onSubmit={handleSubmit}>
        <div className='form-group'>
          <label htmlFor='category'>Category</label>
          <input
            type='text'
            name='category'
            id='category'
            onChange={handleFieldChange}
            required
          />
        </div>
        <div className='form-group'>
          <label htmlFor='user'>User</label>
          <input
            type='text'
            name='user'
            id='user'
            onChange={handleFieldChange}
            required
          />
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
          <input
            type='checkbox'
            name='halal'
            id='halal'
            onChange={handleFieldChange}
          />
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
    </>
  );
};

export default Create;
