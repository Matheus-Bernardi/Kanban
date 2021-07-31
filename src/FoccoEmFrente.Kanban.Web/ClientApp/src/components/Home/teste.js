import React, { useState, useEffect } from "react";

function Titulo(props){
   const upperText = props.children.toUpperCase();

   return props.subtitle 
      ? <h2>{upperText}</h2>
      : <h1>{upperText}</h1>
}

function Paragrafo({titulo, texto}){

   return (
      <>
         <h1>{titulo}</h1>
         <p>{texto}</p>
      </>
   )
}

export default function Home() {

   const [title, setTitle] = useState("");
   const [contador, setContador] = useState(0);

   const onChangeTitle = (event) => {
      setTitle(event.target.value);
   }

   useEffect(() => {
      setContador(contador + 1)
   }, [title]);

   useEffect(() => {
      console.log("iniciou")
   }, [])
   
   return (
      <div>
         <Titulo>{title}</Titulo>
         <Titulo subtitle>Subtitulo</Titulo>
         <p>Count: {contador}</p>
         <input value={title} onChange={onChangeTitle} />
         <Paragrafo titulo="Titulo" texto="Texto" />
      </div>
   );
}
