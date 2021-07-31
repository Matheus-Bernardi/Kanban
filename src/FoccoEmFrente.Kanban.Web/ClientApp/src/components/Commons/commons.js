import React from 'react';

export function Content(props) {

   return (
      <div style={{width: props.width}}>
         {props.children}
      </div>
   );
 }

 export function Paragrafo(props) {

   return (
      <p>{props.children}</p>
   );
}

 export function FormInput(props) {

   return (
      <>
         <label htmlFor={props.id}>{props.label}</label>
         <input 
            id={props.id}
            type={props.type}
            placeholder={props.placeholder}
            value={props.value}
            onChange={props.onChange}
         />
      </>
   );
}

export function Botao(props) {

   const btnClass = (props.type === "secondary") 
      ? "btn btn-secondary"
      : "btn btn-primary"

   return props.submit 
      ? <button type="submit" className={btnClass}>{props.text}</button>
      : <button className={btnClass} onClick={props.onClick}>{props.text}</button>
}