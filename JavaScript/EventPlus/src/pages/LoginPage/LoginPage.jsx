import React, { useContext, useEffect, useState } from "react";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import logo from "../../assets/images/images/logo-pink.svg";
import { Input, Button } from "../../components/FormComponents/FormComponents";
import imageLogin from "../../assets/images/images/login.svg";
import "./LoginPage.css";

import api from "../../Services/Services";
import { UserContext, userDecodeToken } from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";

const LoginPage = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState({ email: "", senha: "" });
  const { userData, setUserData } = useContext(UserContext);

  useEffect(() => {
    if (userData.name) navigate("/"); //manda pra home
  });

  async function handlerSubmit(e) {
    e.preventDefault();

    if (user.senha.trim().length >= 3 && user.email.trim().length >= 3) {
      //chamar a api
      try {
        const retorno = await api.post("/Login", {
          email: user.email,
          senha: user.senha,
        }); //ou passar só "user" que é o objeto, ao invés de colocar as chaves do objeto, se o nome da chave e as props fossem diferentes, n teria como passar somente o "user", mas nesse caso daria

        console.log(retorno.data.token); //pasa esse bichão como parâmetro do userDecodeToken na variavel userFullToken

        const userFullToken = userDecodeToken(retorno.data.token); //bichão ta decodificado
        console.log(userFullToken);

        setUserData(userFullToken); //guarda os dados decodificados (payload)

        localStorage.setItem("token", JSON.stringify(userFullToken)); //guarda no local storage
        
        navigate("/"); //manda usuario pra home
      } catch (error) {
        alert(
          "Usuário ou senha inválidos, ou conexão com a internet comprometida"
        );
      }
    }
  }

  return (
    <div className="layout-grid-login">
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={imageLogin}
            altText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator "
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          <form className="frm-login__formbox" onClick={handlerSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {
                setUser({
                  ...user, //VAI MEXER SOMENTE NO EMAIL, E DEIXANDO NO MESMO OBJECT, REST OPERATOR
                  email: e.target.value,
                });
              }}
              placeholder="Email"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => {
                setUser({
                  ...user, //VAI MEXER SOMENTE NO SENHA, E DEIXANDO NO MESMO OBJECT, REST OPERATOR
                  senha: e.target.value,
                });
              }}
              placeholder="****"
            />

            <a href="" className="frm-login__link">
              Esqueceu a senha?
            </a>

            <Button
              textButton="Login"
              id="btn-login"
              name="btn-login"
              type="submit"
              className="frm-login__button"
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
