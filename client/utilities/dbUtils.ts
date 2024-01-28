import { Superhero } from "./types";

// ADD YOUR HOST HERE....
const host = `http://localhost:5288`;
const uri = `${host}/api/Superhero`;

export async function getSuperheros() {
   return fetch(uri)
      .then((res: any) => res.json() as Array<Superhero>)
      .catch((err: any) => {
         console.error("err getSuperheros", err);
      });
}

export async function getSuperheroById(id: string) {
   return fetch(`${uri}/${id}`)
      .then((res: any) => res.json() as Superhero)
      .catch((err: any) => {
         console.error("err getSuperheros", err);
      });
}

export function createSuperhero(superhero: Superhero) {
   return fetch(uri, {
      method: "POST",
      headers: {
         Accept: "application/json",
         "Content-Type": "application/json",
      },
      body: JSON.stringify(superhero),
   })
      .then((res) => res.json())
      .catch((error) => console.error("Unable to add item.", error));
}

export function deleteSuperhero(id: string) {
   return fetch(`${uri}/${id}`, {
      method: "DELETE",
   })
      .then((res) => res.json())
      .catch((error) => console.error("Unable to delete item.", error));
}

export function updateSuperhero(id: number, superhero: Superhero) {
   return fetch(`${uri}/${id}`, {
      method: "PUT",
      headers: {
         Accept: "application/json",
         "Content-Type": "application/json",
      },
      body: JSON.stringify(superhero),
   })
      .then((res) => res.json())
      .catch((error) => console.error("Unable to update item.", error));
}
