import { useLoader } from '@react-three/fiber';
import { GUI } from 'dat.gui';
import { useEffect, useRef, useState } from 'react';
import { DoubleSide, TextureLoader } from 'three';

interface MeshProps {
    id: string;
    geometry: Array<number>;
    rotationX?: number;
    rotationY?: number;
    rotationZ?: number;
}

const Mesh = (props: MeshProps) => {
    const [wireframe, setWireframe] = useState<boolean>(true);
    const mesh = useRef<THREE.Mesh>(null!);
    const colorMap = useLoader(TextureLoader, 'hay-texture-hay-bales-are-stacked-large-stacks-harvesting-agriculture_158676-1865.avif');
    var obj = {Wireframe: function() {setWireframe(!wireframe)}};
    useEffect(() => {
        const gui = new GUI();
        gui.add(mesh.current.rotation, 'x', 0, Math.PI * 2);
        gui.add(mesh.current.rotation, 'y', 0, Math.PI * 2);
        gui.add(mesh.current.rotation, 'z', 0, Math.PI * 2);
        gui.add(obj, 'Wireframe');
        return () => {
          gui.destroy()
        } 
      }, [wireframe]);

    const positions = new Float32Array(props.geometry.length);
    const indices = new Uint16Array(props.geometry.length / 3);


    for(let i = 0; i < props.geometry.length; i++){
      positions[i] = props.geometry[i];
      indices[i] = i;
    }
      
  
      
    return (
    <mesh key={props.geometry.toString()} rotation-x={props.rotationX} rotation-y={props.rotationY} ref={mesh}>
        <bufferGeometry attach='geometry' onUpdate={geom => geom.computeVertexNormals()}>
          <bufferAttribute attach='attributes-position'
          array={positions}
          count={positions.length / 3}
          itemSize={3} />
          <bufferAttribute attach='index'
          array={indices}
          count={indices.length}
          itemSize={1} />
        </bufferGeometry>
        <meshPhysicalMaterial side={DoubleSide} map={colorMap} wireframe={wireframe}/>
    </mesh>
    
    )
}

export default Mesh;