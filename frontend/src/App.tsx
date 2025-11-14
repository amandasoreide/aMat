import React from "react";
import logo from "./logo.svg";
import "./App.css";
import { useQuery } from "@tanstack/react-query";
import { Recipe } from "./models/Recipe";

/*
async function fetchRecipes(): Promise<string> {
  const res = await fetch("/api/recipes", {
    headers: { Accept: "application/json" },
  });
  if (!res.ok) {
    const text = await res.text();
    throw new Error(`Failed to fetch recipes: ${res.status} ${text}`);
  }
  return res.json();
}
*/

function App() {
  const { data: recipes, error } = useQuery<Recipe[], Error>({
    queryKey: ["recipes"],
    queryFn: async (): Promise<Recipe[]> => {
      const response = await fetch("/api/HttpRecipes");
      return await response.json();
    },
    retry: false, // do not retry on error
  });

  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>aMat</p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
        <p>{recipes?.map((recipe) => recipe.title).join(", ")}</p>
        <p>{error?.message}</p>
      </header>
    </div>
  );
}

export default App;
