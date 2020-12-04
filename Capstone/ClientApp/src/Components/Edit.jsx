import React from "react";

const Edit = () => {
  const handleFieldChange = (e) => {
    switch (e.target.id) {
      case "category":
        // setCategory(e.target.value);
        break;
      case "name":
        // setName(e.target.value);
        break;
      case "price":
        // setPrice(e.target.value);
        break;
      case "description":
        // setDescription(e.target.value);
        break;
      case "wait-time":
        // setWaitTime(e.target.value);
        break;
      case "ingredients":
        // setIngredients(e.target.value);
        break;
      case "calories":
        // setCalories(e.target.value);
        break;
      case "halal":
        // setHalal(true);
        break;
      case "img":
        // setImg(e.target.files[0]);
        break;
    }
  };
  const handleSubmit = (e) => {};

  return (
    <>
      <form onSubmit={handleSubmit}>
        <div className='form-group'>
          <label htmlFor='category'>Category</label>
          <select
            name='category'
            id='category'
            onChange={handleFieldChange}
            value={""}
            required
          >
            {/* {content} */}
          </select>
        </div>
        <div className='form-group'>
          <label htmlFor='name'>Name</label>
          <input
            type='text'
            name='name'
            id='name'
            onChange={handleFieldChange}
            value={""}
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
            value={""}
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
            value={""}
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
            value={""}
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
            value={""}
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
            value={""}
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
            value={""}
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
            value={""}
          />
        </div>
        <div>
          <input type='submit' value='Submit' />
        </div>
      </form>
    </>
  );
};

export default Edit;
