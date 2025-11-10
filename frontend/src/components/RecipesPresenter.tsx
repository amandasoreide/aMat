type Recipe = {
  id: string;
  title: string;
  description?: string;
  // add fields that match your function response
};

async function fetchRecipes(): Promise<Recipe[]> {
  const res = await fetch("/api/recipes", {
    headers: { Accept: "application/json" },
  });
  if (!res.ok) {
    const text = await res.text();
    throw new Error(`Failed to fetch recipes: ${res.status} ${text}`);
  }
  return res.json();
}

export const RecipesPresenter = async () => {
  const recipes = await fetchRecipes();

  return (
    <div>
      <h1>Recipes</h1>
      <ul>
        {recipes.map((recipe) => (
          <li key={recipe.id}>
            <h2>{recipe.title}</h2>
            {recipe.description && <p>{recipe.description}</p>}
          </li>
        ))}
      </ul>
    </div>
  );
};
