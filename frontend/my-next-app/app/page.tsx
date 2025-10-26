import Image from "next/image";

export default function Home() {
  return (
    <div className="mt-10 ">
      {/* title */}
      <div className="my-5 grid grid-col-3 gap-1 flex">
        {/* sprite */}
        <img src ="/fire-spirit.png" className="col-start-1 col-end-1 justify-self-center h-15 w-15"></img>

        {/* name */}
        <h1 className="col-start-2 col-end-2 justify-self-center ">ElementFall</h1>

        {/* sprite */}
        <img src ="/fire-spirit.png" className="col-start-3 col-end-3 justify-self-center h-15 w-15"></img>

      </div>

      {/* download link */}
      <div className="min-h-100 ">
        <p className="mt-50 flex justify-center ">insert download link here</p>
      </div>
    </div>
  );
}
