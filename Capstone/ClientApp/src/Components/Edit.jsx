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
        <pre>{JSON.stringify(menuItem, null, 2)}</pre>

        <div className='form-group'>
          <label htmlFor='category'>Category</label>
          <select name='category' id='category' onChange={handleFieldChange}>
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
            placeholder={menuItem.name}
          />
        </div>
        <div className='form-group'>
          <label htmlFor='price'>Price</label>
          <input
            type='number'
            name='price'
            id='price'
            onChange={handleFieldChange}
            placeholder={menuItem.price}
          />
        </div>
        <div className='form-group'>
          <label htmlFor='description'>Description</label>
          <input
            type='text'
            name='description'
            id='description'
            onChange={handleFieldChange}
            placeholder={menuItem.description}
          />
        </div>
        <div className='form-group'>
          <label htmlFor='wait-time'>Wait Time (Minutes)</label>
          <input
            type='number'
            name='wait-time'
            id='wait-time'
            onChange={handleFieldChange}
            placeholder={menuItem.waitTimeMins}
          />
        </div>
        <div className='form-group'>
          <label htmlFor='Ingredients'>Ingredients</label>
          <input
            type='text'
            name='ingredients'
            id='ingredients'
            onChange={handleFieldChange}
            placeholder={menuItem.ingredients}
          />
        </div>
        <div className='form-group'>
          <label htmlFor='calories'>Calories</label>
          <input
            type='number'
            name='calories'
            id='calories'
            onChange={handleFieldChange}
            placeholder={menuItem.calories}
          />
        </div>
        <div className='form-group'>
          <label htmlFor='halal'>Halal</label>
          <select name='halal' id='halal' onChange={handleFieldChange}>
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
      </>
    );
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setLoading(true);

    const formData = new FormData();
    formData.append("file", img);

    axios({
      method: "put",
      url: "Values/UpdateMenu",
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
      </form>
    </>
  );
};

export default connect((state) => {
  return {
    activeUser: state,
  };
})(Edit);
