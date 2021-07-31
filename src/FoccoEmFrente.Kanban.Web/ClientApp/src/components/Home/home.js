import React, { useState, useEffect } from "react";
import { Content, Paragrafo, Botao } from "../../components/Commons/commons"
import Pipe from "../../components/Home/Pipe/pipe"
import "./home.css";
import HttpRequest from "../../utils/HttpRequest"

export default function Home({history}) {

   const [activities, setActivities] = useState([]);

   const token = localStorage.getItem("token");
   if (!token) history.push("/login");

   const loadActivities = async () => {

      const response = await new HttpRequest("activities", "GET")
         .setToken(token)
         .send();

      if (!response.ok){
         window.alert([
            "Não foi possivel retornar as tarefas!",
            response.errorMessage
         ]);
         return;
      }

      setActivities(response.data);
   }

   const addActivities = async () => {
      
      const activity = {
         title: "Nova atividade",
         status: 0
      }

      const response = await new HttpRequest("activities", "POST")
         .setBody(activity)
         .setToken(token)
         .send();

      if (!response.ok){
         window.alert([
            "Não foi possivel inserir a tarefa!",
            response.errorMessage
         ]);
         return;
      }

      setActivities([...activities, response.data]);
   };

   const updateActivity = async (activity) => {
      
      const response = await new HttpRequest("activities", "PUT")
         .setBody(activity)
         .setToken(token)
         .send();

      if (!response.ok){
         window.alert([
            "Não foi possivel atualizar a tarefa!",
            response.errorMessage
         ]);
         await loadActivities();
         return;
      }
   };

   const updateActivityStatus = async (activityId, status) => {

      const action = status === 0 ? "todo" : status === 1 ? "doing" : "done";
      
      const response = await new HttpRequest(`activities/${activityId}/${action}`, "PUT")
         .setToken(token)
         .send();

      if (!response.ok){
         window.alert([
            "Não foi possivel atualizar o status da tarefa!",
            response.errorMessage
         ]);
         return;
      }

      const activity = activities.find(a => a.id === activityId);
   
      if (!activity)
         return;
         
      activity.status = status;

      setActivities([...activities]);
   }

   const deleteActivity = async (activity) => {
      
      const response = await new HttpRequest(`activities/${activity.id}`, "DELETE")
         .setToken(token)
         .send();

      if (!response.ok){
         window.alert([
            "Não foi possivel excluir a tarefa!",
            response.errorMessage
         ]);
         return;
      }

      setActivities(activities.filter(a => a.id !== activity.id));
   }

   useEffect(() => {
      loadActivities()
   }, []);

   const onLogout = () => {
      localStorage.removeItem("token");
      history.push("/login");
   };

   return (
      <Content width={880}>
         <Paragrafo>Bem vindo ao <strong>Sunday.com</strong>.</Paragrafo>
         <Paragrafo>Esse é seu canvas para organizar suas atividades. Crie novas atividades e mantenha elas sempre atualizadas.</Paragrafo>
            <div className="canvas">
               {
                  [0,1,2].map((status, index) => {
                     return (
                        <Pipe 
                           key={index}
                           status={status}
                           activities={activities}
                           onDelete={deleteActivity}
                           onUpdate={updateActivity}
                           onActivityDrops={(activityId) => updateActivityStatus(activityId, status)}
                        />
                     )
                  })
               }
            </div>
            <Botao text="Adicionar Atividade" onClick={addActivities} />
            <Botao text="Sair" type="secondary" onClick={onLogout} />
      </Content>
   );
}
