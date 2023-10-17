import React, {FC} from "react";


const GetStartedBtn: FC = () => {
    return(
        <button className="rounded-md h-20 w-52 bg-gradient-to-r backdrop-blur-lg from-slate-100/80 to-white/80 border-2 border-black/80">
            <h1 className="text-black font-mukta text-xl ">Get Started</h1>
        </button>
    );
}

export default GetStartedBtn;