import React, {useState} from 'react';
import {
    StyleSheet,
    ScrollView,
    Text,
    TextInput,
    View,
    TouchableOpacity
} from 'react-native';
import axios from 'axios';

const api_url = "https://cookifyv2.azurewebsites.net/api/recipes"

const CreateRecipeView = (props) => {

    const {navigation}= props.route.params;
    
    const [creatorId, setCreatorId] = useState(0);
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");
    const [rating, setRating] = useState(0);
    const [tag, setTag] = useState("");
    const [ingredients, setIngredients] = useState("");

    const changeCreatorId = (e) => {
        setCreatorId(e);
    }

    const changeName = (e) => {
        setName(e);
    }
    const changeDescription = (e) => {
        setDescription(e);
    }
    const changeRating = (e) => {
        setRating(e);
    }
    const changeTag = (e) => {
        setTag(e);
    }
    const changeIngredients = (e) => {
        let arr = e.split(",")
        let list = []
        for(let i=0;i<arr.length;i++){
        list.push({"name":arr[i]})
        }
        setIngredients(list)
    }

    
    const createRecipe = () => {
        axios.post(`${api_url}`, {
            "creatorId": creatorId,
            "name": name,
            "description": description,
            "rating": rating,
            "tag": tag,
            "ingredients": ingredients
        }).then(res => {
            navigation.push("RecipesList")
        })
    }

return(
<ScrollView style={{marginLeft:20}}>
    <Text style={{fontSize: 20, marginBottom: 15, paddingTop: 20}}>Adding new entry: </Text>
    <Text style={styles.description}>Creator Id: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}
            onChangeText = {(e) => changeCreatorId(e)}/>
    </View>
    
    <Text style={styles.description}>Name: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}
            onChangeText = {(e) => changeName(e)}/>
    </View>
    <Text style={styles.description}>Description: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}
            onChangeText = {(e) => changeDescription(e)}/>
    </View> 
    <Text style={styles.description}>Rating: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}
            onChangeText = {(e) => changeRating(e)}/>
    </View>
    <Text style={styles.description}>Tag: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}
            onChangeText = {(e) => changeTag(e)}/>
    </View>
    <Text style={styles.description}>Ingredients: </Text>
    <View style={styles.inputView}>
        <TextInput
            style={styles.TextInput}
            onChangeText = {(e) => changeIngredients(e)}/>
    </View>
    <TouchableOpacity style={styles.createBtn} onPress={createRecipe}>
        <Text style={styles.createText}>Add</Text>
    </TouchableOpacity>
</ScrollView>);
}

export default CreateRecipeView;

const styles = StyleSheet.create({
  
    inputView: {
      backgroundColor: "#d0f0c0",
      borderRadius: 20,
      width: 240,
      height: 45,
      marginBottom: 20,
    },
    TextInput: {
        height: 50,
        flex: 1,
        padding: 10,
        marginLeft: 10,
        opacity: 0.6,
    },
    createText: {
        fontWeight: "bold",
        fontSize: 16,
    },
    createBtn: {
        //width: "80%",
        width: 150,
        borderRadius: 20,
        height: 50,
        alignItems: "center",
        justifyContent: "center",
        marginTop: 20,
        marginBottom: 300,
        backgroundColor: "#00ff00",
    },
    description: {
      marginBottom: 8,
      marginLeft: 8
    }
  });