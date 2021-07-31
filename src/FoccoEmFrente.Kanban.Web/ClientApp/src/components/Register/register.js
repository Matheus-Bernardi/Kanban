import React, { useState } from "react";
import { Content, Paragrafo, FormInput, Botao } from "../../components/Commons/commons"
import HttpRequest from "../../utils/HttpRequest"

export default function Register({history}) {

   const [email, setEmail] = useState("");
   const [password, setPassword] = useState("");
   const [confirmPassword, setConfirmPassword] = useState("");

   const onRegister = async (event) => {
      event.preventDefault();

      const response = await new HttpRequest("account/register", "POST")
         .setBody({
            email: email,
            password: password,
            confirmPassword: confirmPassword
         })
         .send();

      if (!response.ok){
         window.alert(response.errorMessage);
         return;
      }

      localStorage.setItem("token", response.data);
      history.push("/");
   };

   const onBack = () => {
      history.push("/login");
   }

    return (
        <Content width={450}>
           <Paragrafo>Crie uma conta no <strong>Sunday.com</strong></Paragrafo>
           <form onSubmit={onRegister}>
              <FormInput 
                  id="email"
                  type="email"
                  placeholder="E-mail"
                  label="E-mail"
                  value={email}
                  onChange={(event) => setEmail(event.target.value)}
               />
              <FormInput 
                  id="senha"
                  type="password"
                  placeholder="Informe sua Senha"
                  label="Senha"
                  value={password}
                  onChange={(event) => setPassword(event.target.value)}
               />
              <FormInput 
                  id="confirm-senha"
                  type="password"
                  placeholder="Confirmar a Senha"
                  label="Confirmar a Senha"
                  value={confirmPassword}
                  onChange={(event) => setConfirmPassword(event.target.value)}
               />
              <Botao text="Registrar" submit />
              <Botao text="Voltar" type="secondary" onClick={onBack} />
           </form>
        </Content>
     );
}