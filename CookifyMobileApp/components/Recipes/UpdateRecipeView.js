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

const UpdateRecipeView = (props) => {

    const {navigation, recipe} = props.route.params;
    
    const [creatorId, setCreatorId] = useState(recipe.creatorId);
    const [name, setName] = useState(recipe.name);
    const [description, setDescription] = useState(recipe.description);
    const [rating, setRating] = useState(recipe.rating);
    const [tag, setTag] = useState(recipe.tag);
    const [ingredients, setIngredients] = useState(recipe.ingredients);

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
        console.log(ingredients)
    }
    const parseIngredients = (ingredients) => {
        let str = "";
        for(let i = 0; i < ingredients.length; i++) {
            if (i < ingredients.length - 1) {
                str = str + ingredients[i].name + ",";
            } else {
                str = str + ingredients[i].name;
            }
        }
        return str;
    }

    
    const updateRecipe = () => {
        axios.patch(`${api_url}/${recipe.id}`, {
            "creatorId": creatorId,
            "name": name,
            "description": description,
            "rating": rating,
            "tag": tag,
            "ingredients": ingredients
        }).then(res => {
            navigation.push("RecipesList")
            console.log(res)
        })
    }

return(
<ScrollView style={{marginLeft:20}}>
    <Text style={{fontSize: 20, marginBottom: 15, paddingTop: 20}}>Updating this entry: </Text>
    <Text style={styles.description}>Creator Id: </Text>
    <View style={styles.inputView}>
        <TextInput
            value = {creatorId.toString()}
            style = {styles.TextInput}
            onChangeText = {(e) => changeCreatorId(e)}/>
    </View>
    
    <Text style={styles.description}>Name: </Text>
    <View style={styles.inputView}>
        <TextInput
            value = {name}
            style = {styles.TextInput}
            onChangeText = {(e) => changeName(e)}/>
    </View>
    <Text style={styles.description}>Description: </Text>
    <View style={styles.inputView}>
        <TextInput
            value = {description}
            style = {styles.TextInput}
            onChangeText = {(e) => changeDescription(e)}/>
    </View> 
    <Text style={styles.description}>Rating: </Text>
    <View style={styles.inputView}>
        <TextInput
            value = {rating.toString()}
            style = {styles.TextInput}
            onChangeText = {(e) => changeRating(e)}/>
    </View>
    <Text style={styles.description}>Tag: </Text>
    <View style={styles.inputView}>
        <TextInput
            value = {tag}
            style = {styles.TextInput}
            onChangeText = {(e) => changeTag(e)}/>
    </View>
    <Text style={styles.description}>Ingredients: </Text>
    <View style={styles.inputView}>
        <TextInput
            value = {parseIngredients(ingredients)}
            style = {styles.TextInput}
            onChangeText = {(e) => changeIngredients(e)}/>
    </View>
    <TouchableOpacity style={styles.updateBtn} onPress={updateRecipe}>
        <Text style={styles.updateText}>Update</Text>
    </TouchableOpacity>
</ScrollView>);
}

export default UpdateRecipeView;

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
    updateText: {
        fontWeight: "bold",
        fontSize: 16,
    },
    updateBtn: {
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