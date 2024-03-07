import axios from "axios";

const url:string = 'http://localhost:8080/api/GeometryNonSampled/GetArray';

export const getGeometryVector = async (): Promise<any> => {
    try{
        const res =  (await axios.get(url)).data;
        console.log(res);
        return res;
    }
    catch(err){
        console.error(err);
    }
}