import Image from "next/image";

export default function Home() {
  return (
    <div className="mt-10 ">
      {/* title */}
      <div className="my-5 grid grid-col-3 gap-1 flex">
        {/* sprite */}
        <p className="col-start-1 col-end-1 justify-self-center">insert sprite1 here</p>

        {/* name */}
        <h1 className="col-start-2 col-end-2 justify-self-center">ElementalFalls</h1>

        {/* sprite */}
        <p className="col-start-3 col-end-3 justify-self-center">insert sprite2 here</p>

      </div>

      {/* download link */}
      <div className="min-h-100 ">
        <p className="mt-50 flex justify-center ">insert download link here</p>
      </div>
    </div>
  );
}
