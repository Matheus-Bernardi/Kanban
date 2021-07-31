import React, { useState } from "react";
import { Content, Paragrafo, FormInput, Botao } from "../../components/Commons/commons"
import HttpRequest from "../../utils/HttpRequest"

export default function Login({history}) {

   const [formLogin, setFormLogin] = useState({email:"", password:""});

   const setEmail = (event) => {
      setFormLogin({...formLogin, email: event.target.value});
   }

   const setPassword = (event) => {
      setFormLogin({...formLogin, password: event.target.value});
   }

   const onLogin = async (event) => {
      event.preventDefault();

      const response = await new HttpRequest("account/login", "POST")
         .setBody(formLogin)
         .send();

      if (!response.ok){
         window.alert(response.errorMessage);
         return;
      }

      localStorage.setItem("token", response.data);
      history.push("/");
   };

   const onRegister = () => {
      history.push("/register")
   }

   return (
      <Content width={450}>
         <Paragrafo>Bem vindo ao <strong>Sunday.com</strong>, o melhor sistema para gestão de tarefas.</Paragrafo>
         <form onSubmit={onLogin}>
            <FormInput 
               id="email"
               type="email"
               placeholder="E-mail"
               label="E-mail"
               value={formLogin.email}
               onChange={setEmail}
            />
            <FormInput 
               id="senha"
               type="password"
               placeholder="Informe sua Senha"
               label="Senha"
               value={formLogin.password}
               onChange={setPassword}
            />
            <Botao text="Entrar" submit />
            <Botao text="Regisrar" type="secondary" onClick={onRegister} />
         </form>
      </Content>
   );
}