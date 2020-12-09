import React, { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import axios from "axios";
import "../css/Menu.css";

// Renders all menu items categorized by into categories based on the useParams username

const Menu = () => {
  // Refer to index.js for description on useParams
  const { username } = useParams();
  const [menuItems, setMenuItems] = useState([]);
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [path, setPath] = useState();

  // replace method removes the escape characters added in the backend before it was transferred to the database.
  // path + imageName add up to link the image in the projects folder
  const renderMenuItems = (path, categories, menuItems) => {
    return (
      <>
        {categories.map((cat) => {
          return (
            <div key={cat.id}>
              <section className='category' key={cat.id}>
                <h2>{cat.name}</h2>
                <hr />
                <div className='menu-cards'>
                  {menuItems.map((item) => {
                    if (item.categoryID === cat.id) {
                      return (
                        <div key={item.id}>
                          <Link to={"/Details/" + item.id}>
                            <div className='menu-card' id={item.id}>
                              <img src={path + item.imageName} />
                              <div className='title-price'>
                                <h3>{item.name.replace(/\\/g, "")}</h3>
                                <h3>${item.price}</h3>
                              </div>
                              <p>{item.ingredients.replace(/\\/g, "")}</p>
                            </div>
                          </Link>
                        </div>
                      );
                    }
                  })}
                </div>
              </section>
            </div>
          );
        })}
      </>
    );
  };

  // This gets the image path to add the image name onto (Reefer to ValuesController inside controllers folder)
  const populateMenuItems = async () => {
    await axios({
      method: "get",
      url: "Values/ImagePath",
    }).then((response) => {
      setPath(response.data);
    });

    await axios({
      method: "get",
      url: "Values/ListCat",
      params: {
        username: username,
      },
    }).then((response) => {
      setCategories(response.data);
    });

    await axios({
      method: "get",
      url: "Values/ListMenu",
      params: {
        username: username,
      },
    }).then((response) => {
      setMenuItems(response.data);
      setLoading(false);
    });
  };

  useEffect(() => {
    populateMenuItems();
  }, [loading]);

  let content = loading ? (
    <p>Loading...</p>
  ) : (
    renderMenuItems(path, categories, menuItems)
  );

  return <>{content}</>;
};

export default Menu;
