import React, { useState, useEffect } from "react";
import { useParams, Link } from "react-router-dom";
import axios from "axios";
import "../css/Menu.css";

const Menu = () => {
  const { username } = useParams();
  const [menuItems, setMenuItems] = useState([]);
  const [categories, setCategories] = useState([]);
  const [loading, setLoading] = useState(true);
  const [path, setPath] = useState();

  const renderMenuItems = (path, categories, menuItems) => {
    return (
      <>
        {categories.map((cat) => {
          return (
            <>
              <section className='category'>
                <h2>{cat.name}</h2>
                {menuItems.map((item) => {
                  if (item.categoryID === cat.id) {
                    return (
                      <>
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
                      </>
                    );
                  }
                })}
              </section>
            </>
          );
        })}
      </>
    );
  };

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
