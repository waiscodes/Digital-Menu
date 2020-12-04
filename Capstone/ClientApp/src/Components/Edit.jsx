import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { connect } from "react-redux";
import axios from "axios";

const Edit = (props) => {
  const { id } = useParams();
  const [response, setResponse] = useState([]);
  const [catResponse, setCatResponse] = useState();
  const [user, setUser] = useState("test" /*props.activeUser.username*/);
  const [category, setCategory] = useState("");
  const [name, setName] = useState("");
  const [price, setPrice] = useState("");
  const [description, setDescription] = useState("");
  const [waitTime, setWaitTime] = useState("");
  const [ingredients, setIngredients] = useState("");
  const [calories, setCalories] = useState("");
  const [halal, setHalal] = useState("");
  const [img, setImg] = useState();
  const [menuItem, setMenuItem] = useState();
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
        setHalal(true);
        break;
      case "img":
        setImg(e.target.files[0]);
        break;
    }
  };

  const renderEdit = (catResponse, menuItem) => {
    return (
      <>
        <div className='form-group'>
          <label htmlFor='category'>Category</label>
          <select
            name='category'
            id='category'
            onChange={handleFieldChange}
            required
          >
            {catResponse.map((cat) => {
              return (
                <>
                  <option key={cat.id} value={cat.id}>
                    {cat.name}
                  </option>
                </>
              );
            })}
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
          />
        </div>
      </>
    );
  };

  const handleSubmit = (e) => {
    e.preventDefault();
  };

  const populateEdit = async () => {
    await axios({
      method: "get",
      url: "Values/ListCat",
      params: {
        username: user,
      },
    }).then((catList) => {
      setCatResponse(catList.data);
    });

    await axios({
      method: "get",
      url: "Values/GetMenuItem",
      params: {
        id: id,
      },
    }).then((response) => {
      setMenuItem(response.data);
      setLoading(false);
    });
  };

  useEffect(() => {
    populateEdit();
  }, [loading]);
  let content = loading ? <p>Loading...</p> : renderEdit(catResponse, menuItem);

  return (
    <>
      <form onSubmit={handleSubmit}>
        <div>
          {content}
          <input type='submit' value='Submit' />
        </div>
        <pre>{JSON.stringify(menuItem, null, 2)}</pre>
      </form>
    </>
  );
};

export default connect((state) => {
  return {
    activeUser: state,
  };
})(Edit);
