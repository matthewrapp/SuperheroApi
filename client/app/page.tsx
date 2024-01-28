"use client";

import {
   createSuperhero,
   deleteSuperhero,
   getSuperheros,
} from "@/utilities/dbUtils";
import { Superhero } from "@/utilities/types";
import {
   ChangeEvent,
   FormEvent,
   MouseEvent,
   MouseEventHandler,
   useEffect,
   useState,
} from "react";

const defaultSuperhero = { id: "", name: "", superpowers: "" };
export default function Home() {
   const [superheros, setSuperheros] = useState<Array<Superhero>>([]);
   const [superheroConfig, setSuperheroConfig] =
      useState<Superhero>(defaultSuperhero);

   useEffect(() => {
      // on mount fetch superheros
      async function runAsync() {
         // the Get() method request in the superhero controller is cached by 30 seconds...
         // to test the cache, create a new super hero, then refresh the page... you'll see that the new superhero isn't there
         // refresh again after 30 seconds, you should see the new created super hero
         const tempRes = (await getSuperheros()) as Array<Superhero>;
         setSuperheros(tempRes);
      }
      runAsync();
   }, []);

   const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
      setSuperheroConfig((prevState: Superhero) => ({
         ...prevState,
         [e.target?.name]: e.target?.value,
      }));
   };

   const handleSaveSuperHero = async (e: FormEvent<HTMLFormElement>) => {
      e.preventDefault();
      if (!superheroConfig?.name || !superheroConfig?.name?.length)
         return alert("Superhero must have a name!");
      const superHeroToSave = { ...superheroConfig };
      superHeroToSave["id"] = window?.crypto
         ? crypto.randomUUID()
         : Math.random().toString().slice(2, 10);

      const res: boolean = await createSuperhero(superHeroToSave);
      if (res) {
         setSuperheroConfig(defaultSuperhero);
         setSuperheros((prevState) => [...prevState, superHeroToSave]);
      }
   };

   const handleDeleteSuperHero = async (superhero: Superhero) => {
      const res: boolean = await deleteSuperhero(superhero?.id);
      if (res) {
         setSuperheros((prevState) => {
            const copy = [...prevState];
            const ind = copy.findIndex((sh) => sh?.id === superhero?.id);
            copy.splice(ind, 1);
            return copy;
         });
      }
   };

   return (
      <main className="bg-white text-black flex flex-col gap-4 min-h-screen p-24">
         <form
            className="flex flex-col gap-2 w-full"
            onSubmit={handleSaveSuperHero}
         >
            <Title>Create New Superhero</Title>
            <div className="flex flex-row gap-2 items-center">
               <label className="flex flex-col">
                  Superhero Name:
                  <input
                     className="border-[1px] rounded border-gray-700 text-black py-1 px-2"
                     type="text"
                     name="name"
                     placeholder="Superhero Name:"
                     value={superheroConfig?.name}
                     onChange={handleInputChange}
                  />
               </label>
               <label className="flex flex-col w-full">
                  Superhero Powers (Separate by Comma):
                  <input
                     className="border-[1px] rounded border-gray-700 text-black py-1 px-2"
                     type="text"
                     name="superpowers"
                     placeholder="Superhero's Powers:"
                     value={superheroConfig?.superpowers}
                     onChange={handleInputChange}
                  />
               </label>
            </div>
            <button
               type="submit"
               className="border-[1px] rounded bg-green-500 text-white p-1 w-[300px]"
            >
               Create New Superhero
            </button>
         </form>

         <hr />

         <div className="flex flex-col gap-2">
            <Title>Superheros</Title>
            {!!superheros?.length ? (
               <ul className="flex flex-row flex-wrap gap-2">
                  {superheros?.map((sh, i: number) => {
                     return (
                        <Superhero
                           superhero={sh}
                           key={i}
                           handleDeleteSuperHero={(
                              e: MouseEvent<HTMLButtonElement>
                           ) => {
                              e.preventDefault();
                              handleDeleteSuperHero(sh);
                           }}
                        />
                     );
                  })}
               </ul>
            ) : (
               <div>No Superheros created yet... Go ahead & create one!</div>
            )}
         </div>
      </main>
   );
}

const Title = ({ children }: { children: React.ReactNode }) => {
   return (
      <div className="text-black text-[24px] font-semibold">{children}</div>
   );
};

const Superhero = ({
   superhero,
   handleDeleteSuperHero,
}: {
   superhero: Superhero;
   handleDeleteSuperHero: MouseEventHandler<HTMLButtonElement>;
}) => {
   return (
      <li className="card border-[1px] rounded border-gray-700 p-3 flex flex-col gap-2 w-[400px]">
         <div className="flex justify-between items-center">
            <div className="name text-[16px] font-medium">
               {superhero?.name}
            </div>
            <button
               type="button"
               className="cursor-pointer p-2 text-red-500"
               onClick={handleDeleteSuperHero}
            >
               Delete
            </button>
         </div>
         <div className="flex flex-col gap-1">
            <div className="text-[13px]">Powers:</div>
            <ul className="flex gap-1 flex-wrap">
               {superhero?.superpowers
                  ?.split(", ")
                  .map((power: string, i: number) => {
                     return (
                        <li
                           key={i}
                           className="text-[12px] sm:text-[14px] bg-blue-500 rounded-full py-1 text-white px-3"
                        >
                           {power}
                        </li>
                     );
                  })}
            </ul>
         </div>
      </li>
   );
};
