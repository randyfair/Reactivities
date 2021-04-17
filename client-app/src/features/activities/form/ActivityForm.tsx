import { observer } from 'mobx-react-lite';
import { ChangeEvent, useEffect, useState } from 'react';
import { useParams } from 'react-router';
import { Button, Form, FormInput, Segment } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import { v4 as uuid } from 'uuid';
import { Link, useHistory } from 'react-router-dom';


export default observer(function ActivityForm() {
  const history = useHistory();

  const {activityStore} = useStore();
  const {createActivity, updateActivity, loading, loadActivity, loadingInitial} = activityStore;
  const {id} = useParams<{id:string}>();

  const [activity, setActivity] = useState({
    id: '',
    title: '',
    description: '',
    date: '',
    category: '',
    sponsor: '',
    poc: '',
    city: '',
    venue: '',
  });

  useEffect(() => {
    if (id) loadActivity(id).then(activity => setActivity(activity!))
  }, [id, loadActivity])

  function handleSubmit() {
    if (activity.id.length === 0) {
      let newActivity = {
        ...activity,
        id:uuid()
      };
      createActivity(newActivity).then(() => history.push(`/activities/${newActivity.id}`))
    } else {
      updateActivity(activity).then(() => history.push(`/activities/${activity.id}`))
    }
  }

  function handleInputChange(
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) {
    const { name, value } = event.target;
    setActivity({ ...activity, [name]: value });
  }

  if (loadingInitial) return <LoadingComponent content='Loading activity ...'/>

  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit} autoComplete='off'>
        <Form.Input
          placeholder='Title'
          value={activity.title}
          name='title'
          onChange={handleInputChange}
        />
        <Form.TextArea
          placeholder='Description'
          value={activity.description}
          name='description'
          onChange={handleInputChange}
        />
        <FormInput
          placeholder='Category'
          value={activity.category}
          name='category'
          onChange={handleInputChange}
        />
        <FormInput
          type='date'
          placeholder='Date'
          value={activity.date}
          name='date'
          onChange={handleInputChange}
        />
        <FormInput
          placeholder='Sponsor'
          value={activity.sponsor}
          name='sponsor'
          onChange={handleInputChange}
        />
        <FormInput
          placeholder='POC'
          value={activity.poc}
          name='poc'
          onChange={handleInputChange}
        />
        <FormInput
          placeholder='City'
          value={activity.city}
          name='city'
          onChange={handleInputChange}
        />
        <FormInput
          placeholder='Venue'
          value={activity.venue}
          name='venue'
          onChange={handleInputChange}
        />
        <Button
          loading={loading}
          floated='right'
          positive
          type='submit'
          content='Submit'
        />
        <Button
          as={Link} to='/activities'
          floated='right'
          type='button'
          content='Cancel'
        />
      </Form>
    </Segment>
  );
})
